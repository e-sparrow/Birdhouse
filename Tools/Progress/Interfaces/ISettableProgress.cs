namespace Birdhouse.Tools.Progress.Interfaces
{
    public interface ISettableProgress : IProgress
    {
        void SetProgress(float progress);
    }
}