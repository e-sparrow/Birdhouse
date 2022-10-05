namespace Birdhouse.Abstractions.Interfaces
{
    public interface IFlowable
    {
        void SetSpeed(float speed);

        float Speed
        {
            get;
        }
    }
}