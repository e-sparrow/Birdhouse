namespace Birdhouse.Tools.Easing.Interfaces
{
    public interface ICompositeEase : IEase
    {
        void Enqueue(IEase ease, float length);
        void EnqueueVoid(float length);
        
        IEase Dequeue();

        float Length
        {
            get;
        }
    }
}
