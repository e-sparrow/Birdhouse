using System;
using System.Collections.Generic;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Tools.Equality.Factor.Interfaces;

namespace ESparrow.Utils.Tools.Equality.Factor
{
    /// <summary>
    /// Class which compares equality by specified factor.
    /// </summary>
    /// <typeparam name="TSelf">Type to compare</typeparam>
    /// <typeparam name="TFactor">Factor type</typeparam>
    public class FactorEqualityComparer<TSelf, TFactor> : IFactorEqualityComparer<TSelf, TFactor>
    {
        /// <summary>
        /// Creates comparer by specified function which gets factor by self.
        /// </summary>
        /// <param name="equalityFactor">Specified function</param>
        public FactorEqualityComparer(Func<TSelf, TFactor> equalityFactor)
        {
            _equalityFactor = equalityFactor;
        }

        /// <summary>
        /// Directly function.
        /// </summary>
        private readonly Func<TSelf, TFactor> _equalityFactor;

        public bool Equals(TSelf self, object other)
        {
            if (other.IsNull()) return false;
            if (self.IsReferencesMatchWith(other)) return true;

            var typesAreMatch = self.IsTypesMatchWith(other);
            var isEquals = Equals(self, (TSelf) other);

            return typesAreMatch && isEquals;
        }

        /// <summary>
        /// Gets factor by self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Factor to check equality</returns>
        public TFactor GetFactor(TSelf self)
        {
            return _equalityFactor.Invoke(self);
        }
    }
}
