namespace ESparrow.Utils.Access
{
    public class ClassAccessBroker<T> : AccessBrokerBase<T> where T : class
    {
        public ClassAccessBroker(T value) : base(() => value, newValue => value = newValue)
        {
            
        }
    }
}