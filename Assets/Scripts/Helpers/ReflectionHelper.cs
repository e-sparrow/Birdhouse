using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

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

        public static string[] GetMutableMemberNames(this Type type, BindingFlags flags)
        {
            var fields = type.GetFields(flags);
            var properties = type.GetProperties(flags);

            var memberNames = properties.Select(property => property.Name).Concat(fields.Select(field => field.Name)).ToArray();

            return memberNames;
        }
    }
}
