using ESparrow.Utils.Tools.Progress.Interfaces;

namespace ESparrow.Utils.Tools.Progress
{
    public abstract class ProgressBase : IProgress
    {
        public abstract float Current
        {
            get;
        }
    }
}