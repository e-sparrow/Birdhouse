namespace ESparrow.Utils.Tools.Customization.TypeSerialization.Interfaces
{
    public interface ISerializedType
    {
        string TypeName
        {
            get;
            set;
        }

        string AssemblyName
        {
            get;
            set;
        }
    }
}