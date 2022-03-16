using System;
using ESparrow.Utils.Optimization.Memoization.Interfaces;

namespace ESparrow.Utils.Attributes.Pure
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class PureAttributeBase : Attribute
    {
        protected PureAttributeBase(IMemoizationBuffer<object[], object> memoizationBuffer)
        {
            MemoizationBuffer = memoizationBuffer;
        }

        public IMemoizationBuffer<object[], object> MemoizationBuffer
        {
            get;
        }
    }
}