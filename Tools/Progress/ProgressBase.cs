using Birdhouse.Tools.Progress.Interfaces;

namespace Birdhouse.Tools.Progress
{
    public abstract class ProgressBase : IProgress
    {
        public abstract float Current
        {
            get;
        }
    }
}