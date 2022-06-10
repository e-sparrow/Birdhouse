using System;
using System.Reflection;
using ESparrow.Utils.Tools.Customization.TypeSerialization.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Customization.TypeSerialization
{
    [Serializable]
    public struct SerializedType : ISerializedType
    {
        [SerializeField] private string assemblyName;
        [SerializeField] private string typeName;
        
        public string TypeName
        {
            get => typeName;
            set => typeName = value;
        }

        public string AssemblyName
        {
            get => assemblyName;
            set => assemblyName = value;
        }

        public static implicit operator Type(SerializedType type)
        {
            var assembly = Assembly.Load(type.AssemblyName);
            var result = assembly.GetType(type.TypeName);

            return result;
        }
    }
}