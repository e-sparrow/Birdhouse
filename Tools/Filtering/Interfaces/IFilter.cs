using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Strings.Filtering.Interfaces
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filtrate(IEnumerable<T> source);
    }
}