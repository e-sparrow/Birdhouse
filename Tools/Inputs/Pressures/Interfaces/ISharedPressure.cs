using System.Collections.Generic;

namespace Birdhouse.Tools.Inputs.Pressures.Interfaces
{
    public interface ISharedPressure<out TKey>
    {
        IEnumerable<TKey> Keys
        {
            get;
        }
    }
}