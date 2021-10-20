using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Tools.Equality.Factor.Interfaces;

namespace ESparrow.Utils.Tools.Equality.Factor
{
    public abstract class FactorEqualityComparerBase<TSelf, TFactor> : IFactorEqualityComparer<TSelf, TFactor>
    {
        public abstract bool Equals(TSelf self, object other);
        /// <summary>
        /// Checks is self factor equals another one.
        /// </summary>
        /// <param name="self">Self factor</param>
        /// <param name="other">Another one</param>
        /// <returns>True if self factor equals another one and false otherwise</returns>
        protected abstract bool FactorsEquals(TFactor self, TFactor other);

        public float GetEqualityProportion(TSelf self, TSelf other)
        {
            var selfFactors = GetFactors(self).ToArray();
            var otherFactors = GetFactors(other).ToArray();

            if (selfFactors.Length != otherFactors.Length) return 0f;

            int rightFactors = 0;
            for (int i = 0; i < selfFactors.Length; i++)
            {
                bool factorsEquals = FactorsEquals(selfFactors[i], otherFactors[i]);
                if (!factorsEquals)
                {
                    rightFactors++;
                }
            }

            return (float) rightFactors / selfFactors.Length;
        }

        public abstract IEnumerable<TFactor> GetFactors(TSelf self);

        /// <summary>
        /// Compares two same-type variables by GetFactors method.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another value</param>
        /// <returns>True if self value equals another one and false otherwise</returns>
        protected bool Equals(TSelf self, TSelf other)
        {
            return (int) GetEqualityProportion(self, other) == 1;
        }
    }
}
