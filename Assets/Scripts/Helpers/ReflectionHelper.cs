using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Reflection.Operators;
using ESparrow.Utils.Reflection.Operators.Enums;
using ESparrow.Utils.Reflection.Operators.Interfaces;

namespace ESparrow.Utils.Helpers
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

        private const string OperatorPrefix = "op_";
        
        private static readonly Regex DefaultOperatorRegex = new Regex($@"\w*{OperatorPrefix}\w*");

        public static class OperatorHelper
        {
            public static IEnumerable<UnaryOperatorInfo> GetUnaryOperatorInfos(Type type)
            {
                return GetOperatorInfos(type, EOperatorType.Unary).Select(value => value.Inheritor<IOperatorInfo, UnaryOperatorInfo>());
            }

            public static IEnumerable<UnaryOperatorInfo> GetUnaryOperatorInfos(Type type, EUnaryOperatorType operatorTypes)
            {
                return GetUnaryOperatorInfos(type).Where(HasTargetFlag);

                bool HasTargetFlag(UnaryOperatorInfo info)
                {
                    return operatorTypes.HasFlag(info.UnaryOperatorType);
                }
            }

            public static IEnumerable<BinaryOperatorInfo> GetBinaryOperatorInfos(Type type)
            {
                return GetOperatorInfos(type, EOperatorType.Binary).Select(value => value.Inheritor<IOperatorInfo, BinaryOperatorInfo>());
                
                
            }

            public static IEnumerable<BinaryOperatorInfo> GetBinaryOperatorInfos(Type type, EBinaryOperatorType operatorTypes)
            {
                return GetBinaryOperatorInfos(type).Where(HasTargetFlag);

                bool HasTargetFlag(BinaryOperatorInfo info)
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

                var withoutParameters = GetOperatorMethodsWithoutParameters(operatorMethods).ToArray();
                var unaryOperatorInfos = withoutParameters.Select(CreateUnaryOperator);

                var except = operatorMethods.Except(withoutParameters);
                var withOneParameter = GetOperatorMethodsWithParameters(except);
                var binaryOperatorInfos = withOneParameter.Select(CreateBinaryOperator);

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

            private static IEnumerable<MethodInfo> GetOperatorMethodsWithoutParameters(IEnumerable<MethodInfo> methods)
            {
                var fits = methods.Where(value => !value.GetParameters().Any());
                return fits;
            }

            private static IEnumerable<MethodInfo> GetOperatorMethodsWithParameters(IEnumerable<MethodInfo> methods)
            {
                var fits = methods.Where(value => value.GetParameters().Length == 1);
                return fits;
            }

            private static Regex GetOperatorRegex(Type type, EOperatorType operatorType)
            {
                return new Regex($@"\{OperatorPrefix}");
            }

            private static UnaryOperatorInfo CreateUnaryOperator(MethodInfo method)
            {
                var operatorType = EnumsHelper<EUnaryOperatorType>.GetByName(method.Name.Substring(3));
                var result = new UnaryOperatorInfo(method.ReturnType, operatorType);

                return result;
            }

            private static BinaryOperatorInfo CreateBinaryOperator(MethodInfo method)
            {
                var operatorType = EnumsHelper<EBinaryOperatorType>.GetByName(method.Name.Substring(3));
                var anotherArgumentType = method.GetParameters()[0].GetType();
                var result = new BinaryOperatorInfo(method.ReturnType, operatorType, anotherArgumentType);

                return result;
            }
        }
    }
}
