using Birdhouse.Common.Singleton;

namespace Birdhouse.Common.Generic.Holders
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