namespace ESparrow.Utils.Access
{
    public class AccessBroker<T> : AccessBrokerBase<T>
    {
        public AccessBroker(Getter<T> getter, Setter<T> setter) : base(getter, setter)
        {
            
        }
    }
}
