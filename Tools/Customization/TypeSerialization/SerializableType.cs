namespace Birdhouse.Tools.Customization.TypeSerialization
{
    public readonly struct SerializableType
    {
        public SerializableType(string assemblyName, string typeName)
        {
            AssemblyName = assemblyName;
            TypeName = typeName;
        }

        public string AssemblyName
        {
            get;
        }

        public string TypeName
        {
            get;
        }
    }
}