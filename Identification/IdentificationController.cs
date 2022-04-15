using ESparrow.Utils.Helpers;
using ESparrow.Utils.Identification.Interfaces;

namespace ESparrow.Utils.Identification
{
    public class IdentificationController<T> : IdentificationControllerBase<T>
    {
        public IdentificationController() : this(IdentificationHelper.GetBlankUnifier<T>())
        {
            
        }

        public IdentificationController(IUnifier<T> unifier) : base(unifier)
        {
            
        }

        protected override bool IsIdentical(T left, T right)
        {
            return left.Equals(right);
        }
    }
}