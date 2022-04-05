using ESparrow.Utils.Drawers.Interfaces;

namespace ESparrow.Utils.Drawers.Adapters.AsGizmos
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