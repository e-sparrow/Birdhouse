using Birdhouse.Tools.Drawers.Interfaces;

namespace Birdhouse.Tools.Drawers.Adapters.Gizmos
{
    public abstract class ToDrawableAdapterBase<T> : IDrawable
    {
        protected ToDrawableAdapterBase(T self)
        {
            Self = self;
        }

        protected readonly T Self;

        public abstract void Draw(IWayDrawer wayDrawer);
    }
}