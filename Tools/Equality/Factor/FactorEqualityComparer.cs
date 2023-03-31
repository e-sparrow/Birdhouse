using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Tools.Equality.Factor
{
    /// <summary>
    /// Class which compares equality by specified factor.
    /// </summary>
    /// <typeparam name="TSelf">Type to compare</typeparam>
    /// <typeparam name="TFactor">Factor type</typeparam>
    public class FactorEqualityComparer<TSelf, TFactor> : FactorEqualityComparerBase<TSelf, TFactor>
    {
        /// <summary>
        /// Creates comparer by specified function which gets factor by self.
        /// </summary>
        /// <param name="equalityFactor">Specified function</param>
        public FactorEqualityComparer(Func<TSelf, IEnumerable<TFactor>> equalityFactor)
        {
            _equalityFactor = equalityFactor;
        }

        /// <summary>
        /// Directly function.
        /// </summary>
        private readonly Func<TSelf, IEnumerable<TFactor>> _equalityFactor;

        public override bool Equals(TSelf self, object other)
        {
            if (other.IsNull()) return false;
            if (self.IsReferencesMatchWith(other)) return true;
            
            var typesAreMatch = self.AreTypesMatchWith(other);
            var isEquals = Equals(self, (TSelf) other);

            return typesAreMatch && isEquals;
        }

        public override IEnumerable<TFactor> GetFactors(TSelf self)
        {
            return _equalityFactor.Invoke(self);
        }

        protected override bool FactorsEquals(TFactor self, TFactor other)
        {
            var comparer = EqualityComparer<TFactor>.Default;
            bool equals = comparer.Equals(self, other);

            return equals;
        }
    }
}
