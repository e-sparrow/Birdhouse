using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ESparrow.Utils.Conversion;
using ESparrow.Utils.Conversion.Adapters;
using ESparrow.Utils.Conversion.Enums;
using ESparrow.Utils.Conversion.Interfaces;
using ESparrow.Utils.Reflection.Operators;
using ESparrow.Utils.Reflection.Operators.Enums;
using ESparrow.Utils.Reflection.Operators.Interfaces;

namespace ESparrow.Utils.Helpers
{
    public static class ConversionHelper
    {
        private static readonly List<ITypedConversionInfo> TypedConversionInfos = new List<ITypedConversionInfo>()
        {
            
        };

        private static readonly Lazy<List<ITypedConversion>> Conversions = new Lazy<List<ITypedConversion>>(InitializeConversions);

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
                bool parameterless = methodInfo.GetParameters().Length == 0;
                bool suitableType = methodInfo.ReturnType == final;

                return parameterless && suitableType;
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
                
                bool suitableParametersCount = parameters.Length == 1;
                bool suitableParameterType = parameters.First().ParameterType == original;
                
                return suitableParametersCount && suitableParameterType;
            }
        }

        private static List<ITypedConversion> InitializeConversions()
        {
            var typedConversions = TypedConversionInfos.Select(value => new TypedConversion(value) as ITypedConversion);
            return typedConversions.ToList();
        }

        private static bool HasConversion(Type originalType, Type finalType)
        {
            return Conversions.Value.Any(value => IsFitConversion(value.Info, originalType, finalType));
        }

        private static bool IsFitConversion(IConversionInfo info, Type originalType, Type finalType)
        {
            return info.OriginalType == originalType && info.FinalType == finalType;
        }

        private static IEnumerable<ITypedConversion> AvailableConversions(Type originalType)
        {
            return Conversions.Value.FindAll(value => value.Info.OriginalType == originalType);
        }

        private static ITypedConversion FindConversion(Type originalType, Type finalType)
        {
            return Conversions.Value.Find(value => value.Info.OriginalType == originalType && value.Info.FinalType == finalType);
        }
    }
}
