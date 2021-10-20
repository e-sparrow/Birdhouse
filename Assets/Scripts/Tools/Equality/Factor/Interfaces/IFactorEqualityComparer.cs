using System.Collections.Generic;
using ESparrow.Utils.Tools.Equality.Interfaces;

namespace ESparrow.Utils.Tools.Equality.Factor.Interfaces
{
    public interface IFactorEqualityComparer<in TSelf, out TFactor> : Equality.Interfaces.IEqualityComparer<TSelf>
    {
        /// <summary>
        /// Gets an equality proportion of two objects.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another value</param>
        /// <returns>
        /// Value between 0 and 1 - from absolutely mismatch to fully equality
        /// </returns>
        float GetEqualityProportion(TSelf self, TSelf other);
        
        /// <summary>
        /// Gets a factor by self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Factor for check the equality</returns>
        IEnumerable<TFactor> GetFactors(TSelf self);
    }
}
