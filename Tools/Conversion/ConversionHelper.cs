using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using Birdhouse.Abstractions;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Operators.Enums;
using Birdhouse.Common.Reflection.Operators.Interfaces;
using Birdhouse.Tools.Conversion.Adapters;
using Birdhouse.Tools.Conversion.Enums;
using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion
{
    public static class ConversionHelper
    {
        private static readonly Lazy<List<ITypedConversion>> Conversions = new Lazy<List<ITypedConversion>>();

        public static ISpecificTypedConversion<TFrom, TTo> GetDefaultConversion<TFrom, TTo>()
        {
            var conversion = new SpecificTypedConversion<TFrom, TTo>(Convert);
            return conversion;

            TTo Convert(TFrom value)
            {
                if (TryConvert<TFrom, TTo>(value, out var result))
                {
                    return result;
                }

                throw new ArgumentException($"Can't find some possible ways to convert {typeof(TFrom)} to {typeof(TTo)}");
            }
        }

        public static IReversibleSpecificTypedConversion<TFrom, TTo> GetDefaultReversibleConversion<TFrom, TTo>()
        {
            var forward = GetDefaultConversion<TFrom, TTo>();
            var back = GetDefaultConversion<TTo, TFrom>();

            var result = forward.Combine(back);
            return result;
        }

        public static bool TryConvert<TFrom, TTo>(TFrom self, out TTo result, EConversionType conversionType = EConversionType.All)
        {
            var originalType = typeof(TFrom);
            var finalType = typeof(TTo);
            
            if (conversionType.HasFlag(EConversionType.Marked) && HasConversion(originalType, finalType))
            {
                result = (TTo) FindConversion(originalType, finalType).Convert(self);
                return true;
            }
            
            if (TryGenerateConversion(originalType, finalType, conversionType, out var conversion))
            {
                result = (TTo) conversion.Convert(self);
                return true;
            }

            result = default;
            return false;
        }

        public static IDisposable RegisterTypedConversion(ITypedConversion conversion)
        {
            var result = conversion.AddAsDisposableTo(Conversions.Value);
            return result;
        }

        public static IDisposable RegisterConversion(ITypedConversion conversion)
        {
            var result = conversion.AddAsDisposableTo(Conversions.Value);
            return result;
        }

        public static IDisposable RegisterSpecificTypedConversion<TFrom, TTo>(ISpecificTypedConversion<TFrom, TTo> conversion)
        {
            var result = conversion
                .IsNotSpecific()
                .AddAsDisposableTo(Conversions.Value);
            
            return result;
        }

        public static IDisposable RegisterReversibleSpecificTypedConversion<TFrom, TTo>(IReversibleSpecificTypedConversion<TFrom, TTo> conversion)
        {
            var conversions = conversion.Split();
             
            var disposable = conversions.AddAsDisposablesTo(Conversions.Value);
            return disposable;
        }

        private static bool TryGenerateConversion(Type original, Type final, EConversionType conversionType, out ITypedConversion result)
        {
            result = default;

            if (conversionType.HasFlag(EConversionType.ExplicitOperator))
            {
                if (TryGetSuitableOperator(original, final, EUnaryOperatorType.Explicit, out var operatorInfo))
                {
                    result = new UnaryOperatorToTypedConversionAdapter(original, operatorInfo);
                    return true;
                }
            }
            else if (conversionType.HasFlag(EConversionType.ImplicitOperator))
            {
                if (TryGetSuitableOperator(original, final, EUnaryOperatorType.Implicit, out var operatorInfo))
                {
                    result = new UnaryOperatorToTypedConversionAdapter(original, operatorInfo);
                    return true;
                }
            }
            else if (conversionType.HasFlag(EConversionType.Method))
            {
                if (TryGetSuitableMethod(original, final, out var method))
                {
                    result = new MethodToTypedConversionAdapter(method);
                    return true;
                }
            }
            else if (conversionType.HasFlag(EConversionType.Constructor))
            {
                if (TryGetSuitableConstructor(original, final, out var constructor))
                {
                    result = new ConstructorToTypedConversionAdapter(constructor);
                    return true;
                }
            }

            return false;
        }

        private static bool TryGetSuitableOperator(Type original, Type final, EUnaryOperatorType operatorTypes, out IUnaryOperatorInfo result)
        {
            var operatorInfos = ReflectionHelper.OperatorHelper.GetUnaryOperatorInfos(original, operatorTypes);
            var array = operatorInfos.ToArray();
            
            if (array.Length > 0)
            {
                result = array.FirstOrDefault(IsFit);

                if (result == default) return false;
                
                return true;
            }
            
            result = default;
            return false;

            bool IsFit(IUnaryOperatorInfo operatorInfo)
            {
                var suitableType = operatorInfo.ReturnType == final;
                return suitableType;
            }
        }

        private static bool TryGetSuitableMethod(Type original, Type final, out MethodInfo result)
        {
            result = default;
            
            var methods = original.GetMethods();
            var target = methods.FirstOrDefault(IsFit);

            if (target == default) return false;
            
            result = target;
            return true;

            bool IsFit(MethodInfo methodInfo)
            {
                var parameterless = methodInfo.GetParameters().Length == 0;
                var suitableType = methodInfo.ReturnType == final;

                var isFit = parameterless && suitableType;
                return isFit;
            }
        }

        private static bool TryGetSuitableConstructor(Type original, Type final, out ConstructorInfo result)
        {
            result = default;
            
            var constructors = final.GetConstructors();
            var target = constructors.FirstOrDefault(IsFit);

            if (target == default) return false;

            result = target;
            return true;

            bool IsFit(ConstructorInfo constructorInfo)
            {
                var parameters = constructorInfo.GetParameters();
                
                var suitableParametersCount = parameters.Length == 1;
                var suitableParameterType = parameters.First().ParameterType == original;

                var result = suitableParametersCount && suitableParameterType;
                return result;
            }
        }

        private static bool HasConversion(Type originalType, Type finalType)
        {
            var result = Conversions
                .Value
                .Any(value => IsFitConversion(value.Info, originalType, finalType));
            
            return result;
        }

        private static bool IsFitConversion(IConversionInfo info, Type originalType, Type finalType)
        {
            var isOriginalFit = info.OriginalType == originalType;
            var isFinalFit = info.FinalType == finalType;

            var result = isOriginalFit && isFinalFit;
            return result;
        }

        private static IEnumerable<ITypedConversion> AvailableConversions(Type originalType)
        {
            var result = Conversions
                .Value
                .FindAll(value => value.Info.OriginalType == originalType);
            
            return result;
        }

        private static ITypedConversion FindConversion(Type originalType, Type finalType)
        {
            var result = Conversions
                .Value
                .Find(value => IsFitConversion(value.Info, originalType, finalType));
            
            return result;
        }
    }
}
