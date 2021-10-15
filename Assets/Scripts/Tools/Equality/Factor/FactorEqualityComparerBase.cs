using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Tools.Equality.Factor.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Equality.Factor
{
    public abstract class FactorEqualityComparerBase<TSelf, TFactor> : IFactorEqualityComparer<TSelf, TFactor>
    {
        public abstract bool Equals(TSelf self, object other);
        public abstract TFactor GetFactor(TSelf self);
        
        protected bool Equals(TSelf self, TSelf other)
        {
            return EqualityComparer<TFactor>.Default.Equals(GetFactor(self), GetFactor(other));
        }
    }
}
