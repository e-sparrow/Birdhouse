using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Operators;
using Birdhouse.Common.Reflection.Operators.Enums;
using Birdhouse.Common.Reflection.Operators.Interfaces;

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
                return GetOperatorInfos(type, EOperatorType.Unary).Select(value => value.Inheritor<IOperatorInfo, UnaryOperatorInfo>());
            }

            public static IEnumerable<IUnaryOperatorInfo> GetUnaryOperatorInfos(Type type, EUnaryOperatorType operatorTypes)
            {
                return GetUnaryOperatorInfos(type).Where(HasTargetFlag);

                bool HasTargetFlag(IUnaryOperatorInfo info)
                {
                    return operatorTypes.HasFlag(info.UnaryOperatorType);
                }
            }

            public static IEnumerable<IBinaryOperatorInfo> GetBinaryOperatorInfos(Type type)
            {
                return GetOperatorInfos(type, EOperatorType.Binary).Select(value => value.Inheritor<IOperatorInfo, BinaryOperatorInfo>());
            }

            public static IEnumerable<IBinaryOperatorInfo> GetBinaryOperatorInfos(Type type, EBinaryOperatorType operatorTypes)
            {
                return GetBinaryOperatorInfos(type).Where(HasTargetFlag);

                bool HasTargetFlag(IBinaryOperatorInfo info)
                {
                    return operatorTypes.HasFlag(info.BinaryOperatorType);
                }
            }

            public static IEnumerable<IOperatorInfo> GetOperatorInfos(Type type, EOperatorType operatorTypes)
            {
                return GetAllOperatorInfos(type).Where(HasTargetFlag);

                bool HasTargetFlag(IOperatorInfo info)
                {
                    return operatorTypes.HasFlag(info.OperatorType);
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

                return unaryOperatorInfos.SelectBase<UnaryOperatorInfo, IOperatorInfo>().Concat(binaryOperatorInfos);
            }

            private static IEnumerable<MethodInfo> GetOperatorMethods(IEnumerable<MethodInfo> methods)
            {
                var fits = methods.Where(DelegateHelper.All<MethodInfo>(IsFitByProperties, IsFitByAttributes, IsFitByName));
                return fits;
            }

            private static bool IsFitByProperties(MethodInfo method)
            {
                return method.IsSpecialName && method.IsHideBySig;
            }

            private static bool IsFitByAttributes(MethodInfo method)
            {
                return method.Attributes == DefaultOperatorAttributesValue;
            }

            private static bool IsFitByName(MethodInfo method)
            {
                return DefaultOperatorRegex.IsMatch(method.Name);
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
                return methodInfo.GetParameters().Length == 1;
            }

            private static bool IsBinary(MethodInfo methodInfo)
            {
                return methodInfo.GetParameters().Length == 2;
            }
        }
    }
}
