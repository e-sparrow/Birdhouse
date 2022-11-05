using System.Collections.Generic;

namespace Birdhouse.Common.Singleton.Interfaces
{
    public interface ISingletonStrategy<out T>
    {
        IEnumerable<T> FindInstances();
        T CreateInstance();
    }
}