namespace ESparrow.Utils.Reflection.Interfaces
{
    public interface IMutableMember
    {
        public void SetValue(object value, object subject);
        public object GetValue(object subject);
    }

    public interface IMutableMember<T> : IMutableMember
    {
        public void SetValue(T value, object subject);
        new public T GetValue(object subject);
    }
}
