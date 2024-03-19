using System;
using System.Reflection;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class MethodToReadableAdapter
        : ToReadableAdapterBase<MethodInfo>
    {
        public MethodToReadableAdapter(MethodInfo readable) 
            : base(readable)
        {
            
        }

        protected override object GetValue(MethodInfo readable, object target)
        {
            var result = readable.Invoke(target, Array.Empty<object>());
            return result;
        }
    }
}