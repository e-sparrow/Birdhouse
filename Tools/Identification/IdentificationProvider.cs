using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Tools.Identification
{
    public class IdentificationProvider<T> : IdentificationProviderBase<T>
    {
        public IdentificationProvider() : this(IdentificationHelper.GetBlankUnifier<T>())
        {
            
        }

        public IdentificationProvider(IUnifier<T> unifier) : base(unifier)
        {
            
        }

        protected override bool IsIdentical(T left, T right)
        {
            var result = left.Equals(right);
            return result;
        }
    }
}