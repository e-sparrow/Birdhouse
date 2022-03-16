using ESparrow.Utils.Generalization.TextInterface.Interfaces;

namespace ESparrow.Utils.Generalization.TextInterface.Adapters
{
    public abstract class ToTextAdapterBase : IText
    {
        public abstract string Text
        {
            get;
            set;
        }
    }
}
