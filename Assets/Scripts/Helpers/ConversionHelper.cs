using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Conversion;
using ESparrow.Utils.Conversion.Enums;
using ESparrow.Utils.Conversion.Interfaces;
using ESparrow.Utils.Reflection.Operators;
using ESparrow.Utils.Reflection.Operators.Enums;

namespace ESparrow.Utils.Helpers
{
    public static class ConversionHelper
    {
        private static readonly List<ITypedConversionInfo> TypedConversionInfos = new List<ITypedConversionInfo>()
        {
            
        };

        private static readonly Lazy<List<ITypedConversion>> Conversions = new Lazy<List<ITypedConversion>>(InitializeConversions);

        public static bool TryConvert<TFrom, TTo>(TFrom self, out TTo result)
        {
            var originalType = typeof(TFrom);
            var finalType = typeof(TTo);
            
            if (HasConversion(originalType, finalType))
            {
                result = (TTo) FindConversion(originalType, finalType).Convert(self);
                return true;
            }
            else if (TryGenerateConversion(originalType, finalType, EConversionType.All, out var conversion))
            {
                result = (TTo) conversion.Convert(self);
                return true;
            }

            result = default;
            return false;
        }

        public static bool TryGenerateConversion(Type original, Type final, EConversionType conversionType, out ITypedConversion result)
        {
            result = default;

            if (conversionType.HasFlag(EConversionType.ExplicitOperator))
            {
                if (TryGenerateConversionFromOperator(original, final, EUnaryOperatorType.Explicit, out var operatorInfo))
                {
                    result = new TypedConversion(new TypedConversionInfo(original, final, operatorInfo.Invoke));
                    return true;
                }
            }
            else if (conversionType.HasFlag(EConversionType.ImplicitOperator))
            {
                if (TryGenerateConversionFromOperator(original, final, EUnaryOperatorType.Implicit, out var operatorInfo))
                {
                    result = new TypedConversion(new TypedConversionInfo(original, final, operatorInfo.Invoke));
                    return true;
                }
            }
            else if (conversionType.HasFlag(EConversionType.Method))
            {
                // TODO: найти методы без параметров с нужными возвращаемыми типами в типе original
            }
            else if (conversionType.HasFlag(EConversionType.Constructor))
            {
                // TODO: найти конструктор с параметром типа original в классе final
            }

            return false;
        }

        private static bool TryGenerateConversionFromOperator(Type original, Type final, EUnaryOperatorType operatorTypes, out UnaryOperatorInfo result)
        {
            var operatorInfos = ReflectionHelper.OperatorHelper.GetUnaryOperatorInfos(original, operatorTypes);
            var array = operatorInfos.ToArray();
            
            if (array.Length > 0)
            {
                result = array.FirstOrDefault(value => value.ReturnType == final);
                return true;
            }
            
            result = default;
            return false;
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
