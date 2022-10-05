using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Operators;
using Birdhouse.Common.Reflection.Operators.Enums;
using Birdhouse.Common.Reflection.Operators.Interfaces;
using Birdhouse.Tools.Conversion;

namespace Birdhouse.Common.Helpers
{
    public static class ReflectionHelper
    {
        public const BindingFlags AnyBindingFlags =
            BindingFlags.Default |
            BindingFlags.IgnoreCase |
            BindingFlags.DeclaredOnly |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.FlattenHierarchy |
            BindingFlags.InvokeMethod |
            BindingFlags.CreateInstance |
            BindingFlags.GetField |
            BindingFlags.SetField |
            BindingFlags.GetProperty |
            BindingFlags.SetProperty |
            BindingFlags.PutDispProperty |
            BindingFlags.PutRefDispProperty |
            BindingFlags.ExactBinding |
            BindingFlags.SuppressChangeType |
            BindingFlags.OptionalParamBinding |
            BindingFlags.IgnoreReturn;

        private const MethodAttributes DefaultOperatorAttributesValue = (MethodAttributes) 2198;

        public static class OperatorHelper
        {
            private const string OperatorPrefix = "op_";
            private static readonly Regex DefaultOperatorRegex = new Regex($@"\w*{OperatorPrefix}\w*");
            
            public static IEnumerable<IUnaryOperatorInfo> GetUnaryOperatorInfos(Type type)
            {
                var infos = GetOperatorInfos(type, EOperatorType.Unary);
                
                var result = infos.SelectInheritor<IOperatorInfo, UnaryOperatorInfo>();
                return result; 
            }

            public static IEnumerable<IUnaryOperatorInfo> GetUnaryOperatorInfos(Type type, EUnaryOperatorType operatorTypes)
            {
                var infos = GetUnaryOperatorInfos(type);

                var result = infos.Where(HasTargetFlag);
                return result;

                bool HasTargetFlag(IUnaryOperatorInfo info)
                {
                    var hasFlag = operatorTypes.HasFlag(info.UnaryOperatorType);
                    return hasFlag;
                }
            }

            public static IEnumerable<IBinaryOperatorInfo> GetBinaryOperatorInfos(Type type)
            {
                var infos = GetOperatorInfos(type, EOperatorType.Binary);

                var result = infos.Select(value => value.Inheritor<IOperatorInfo, BinaryOperatorInfo>());
                return result;
            }

            public static IEnumerable<IBinaryOperatorInfo> GetBinaryOperatorInfos(Type type, EBinaryOperatorType operatorTypes)
            {
                var infos = GetBinaryOperatorInfos(type);
                
                var result = infos.Where(HasTargetFlag);
                return result;

                bool HasTargetFlag(IBinaryOperatorInfo info)
                {
                    var hasFlag = operatorTypes.HasFlag(info.BinaryOperatorType);
                    return hasFlag;
                }
            }

            public static IEnumerable<IOperatorInfo> GetOperatorInfos(Type type, EOperatorType operatorTypes)
            {
                var infos = GetAllOperatorInfos(type);
                
                var result = infos.Where(HasTargetFlag);
                return result;

                bool HasTargetFlag(IOperatorInfo info)
                {
                    var hasFlag = operatorTypes.HasFlag(info.OperatorType);
                    return hasFlag;
                }
            }

            public static IEnumerable<IOperatorInfo> GetAllOperatorInfos(Type type)
            {
                var methods = type.GetMethods();
                var operatorMethods = GetOperatorMethods(methods).ToArray();

                var unaryOperatorMethods = GetUnaryOperatorMethods(operatorMethods).ToArray();
                var unaryOperatorInfos = unaryOperatorMethods.Select(CreateUnaryOperator);

                var except = operatorMethods.Except(unaryOperatorMethods);
                var binaryOperatorMethods = GetBinaryOperatorMethods(except);
                var binaryOperatorInfos = binaryOperatorMethods.Select(CreateBinaryOperator);

                var result = unaryOperatorInfos
                    .SelectBase<UnaryOperatorInfo, IOperatorInfo>()
                    .Concat(binaryOperatorInfos);
                
                return result;
            }

            private static IEnumerable<MethodInfo> GetOperatorMethods(IEnumerable<MethodInfo> methods)
            {
                var predicate = new Predicate<MethodInfo>(IsFitByProperties).And(IsFitByAttributes).And(IsFitByName);
                
                var fits = methods.Where(predicate.Invoke);
                return fits;
            }

            private static bool IsFitByProperties(MethodInfo method)
            {
                var result = method.IsSpecialName && method.IsHideBySig;
                return result;
            }

            private static bool IsFitByAttributes(MethodInfo method)
            {
                var result = method.Attributes == DefaultOperatorAttributesValue;
                return result;
            }

            private static bool IsFitByName(MethodInfo method)
            {
                var result = DefaultOperatorRegex.IsMatch(method.Name);
                return result;
            }

            private static IEnumerable<MethodInfo> GetUnaryOperatorMethods(IEnumerable<MethodInfo> methods)
            {
                var fits = methods.Where(IsUnary);
                return fits;
            }

            private static IEnumerable<MethodInfo> GetBinaryOperatorMethods(IEnumerable<MethodInfo> methods)
            {
                var fits = methods.Where(IsBinary);
                return fits;
            }

            private static UnaryOperatorInfo CreateUnaryOperator(MethodInfo method)
            {
                var operatorType = GetOperatorTypeByName<EUnaryOperatorType>(method.Name);
                var result = new UnaryOperatorInfo(method.ReturnType, operatorType);

                return result;
            }

            private static BinaryOperatorInfo CreateBinaryOperator(MethodInfo method)
            {
                var operatorType = GetOperatorTypeByName<EBinaryOperatorType>(method.Name);
                var anotherArgumentType = method.GetParameters()[0].GetType();
                var result = new BinaryOperatorInfo(method.ReturnType, operatorType, anotherArgumentType);

                return result;
            }

            private static TType GetOperatorTypeByName<TType>(string name) where TType : Enum
            {
                var target = EnumsHelper<TType>.GetByName(name.Substring(3));
                return target;
            }

            private static bool IsUnary(MethodInfo methodInfo)
            {
                var result = methodInfo.GetParameters().Length == 1;
                return result;
            }

            private static bool IsBinary(MethodInfo methodInfo)
            {
                var result = methodInfo.GetParameters().Length == 2;
                return result;
            }
        }
    }
}
