using System.Collections.Generic;
using ESparrow.Utils.Tools.Equality.Interfaces;

namespace ESparrow.Utils.Tools.Equality.Factor.Interfaces
{
    public interface IFactorEqualityComparer<in TSelf, out TFactor> : IEqualityComparer<TSelf, object>
    {
        /// <summary>
        /// Gets a factor by self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Factor for check the equality</returns>
        IEnumerable<TFactor> GetFactors(TSelf self);
    }
}
