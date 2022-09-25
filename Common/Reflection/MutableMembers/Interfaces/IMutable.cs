namespace Birdhouse.Common.Reflection.MutableMembers.Interfaces
{
    public interface IMutable
    {
        void SetValue(object subject, object value);
        object GetValue(object subject);

        string Name
        {
            get;
        }
    }
}