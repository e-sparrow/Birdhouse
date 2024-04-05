namespace Birdhouse.Abstractions.Interfaces
{
    public interface IInitializable
    {
        void Initialize();
    }

    public interface IInitializable<in TInput>
    {
        void Initialize(TInput input);
    }

    public interface IInitializable<in TInput, out TOutput>
    {
        TOutput Initialize(TInput input);
    }

    public interface IResultingInitializable<out TOutput>
    {
        TOutput Initialize();
    }
}