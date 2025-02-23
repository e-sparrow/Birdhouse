namespace Birdhouse.Abstractions.Misc
{
    public interface IEnable
        : IReadOnlyEnable
    {
        void SetEnabled(bool isEnabled);
    }

    public interface IReadOnlyEnable
    {
        bool IsEnabled
        {
            get;
        }
    }
}