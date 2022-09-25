using Birdhouse.Tools.Generalization.TextInterface.Interfaces;

namespace Birdhouse.Tools.Generalization.TextInterface.Adapters
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
