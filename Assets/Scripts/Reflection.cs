using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils
{
    public static class Reflection
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
    }
}
