using System.Reflection;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public class MethodToWritableAdapter
        : ToWritableAdapterBase<MethodInfo>
    {
        public MethodToWritableAdapter(MethodInfo writable) 
            : base(writable)
        {
            
        }

        protected override void SetValue(MethodInfo writable, object target, object value)
        {
            writable.Invoke(target, value.AsSingleArray());
        }
    }
}