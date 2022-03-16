namespace ESparrow.Utils.Patterns.Singleton
{
    public class SingletonHolder<T> : SingletonBase<SingletonHolder<T>>
    {
        public T Value
        {
            get;
            set;
        }
    }
}