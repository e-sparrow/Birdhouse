using System.Collections.Generic;

namespace Birdhouse.Tools.Equality.Factor.Interfaces
{
    public interface IFactorEquatable<TFactor>
    {
        /// <summary>
        /// Gets equality proportion of this and another object.
        /// </summary>
        /// <param name="other">Another object</param>
        /// <returns>
        /// Equality proportion between 0 and 1 - from absolutely mismatch to fully equality
        /// </returns>
        float GetEqualityProportion(IFactorEquatable<TFactor> other);
        
        /// <summary>
        /// Gets a factor by self value.
        /// </summary>
        /// <returns>Factor for check the equality</returns>
        IEnumerable<TFactor> GetFactors();
    }

    public interface IFactorEquatable : IFactorEquatable<object>
    {
        
    }
}