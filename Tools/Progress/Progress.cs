using Birdhouse.Tools.Progress.Interfaces;

namespace Birdhouse.Tools.Progress
{
    public class Progress : ProgressBase, ISettableProgress
    {
        public Progress(float current)
        {
            _current = current;
        }

        private float _current;

        public override float Current => _current;

        public void SetProgress(float progress)
        {
            _current = progress;
        }
    }
}