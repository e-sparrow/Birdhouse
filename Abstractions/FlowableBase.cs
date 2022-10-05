using Birdhouse.Abstractions.Interfaces;

namespace Birdhouse.Abstractions
{
    public abstract class FlowableBase : IFlowable
    {
        protected abstract void SetSpeedInternal(float speed);
        
        public void SetSpeed(float speed)
        {
            SetSpeedInternal(speed);
            Speed = speed;
        }

        public float Speed
        {
            get;
            private set;
        }
    }
}