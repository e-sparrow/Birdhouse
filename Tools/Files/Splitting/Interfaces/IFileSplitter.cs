namespace Birdhouse.Tools.Files.Splitting.Interfaces
{
    public interface IFileSplitter
    {
        void Split(IFileSplittingSettings settings);
        void Merge(IFileSplittingSettings settings);
    }
}