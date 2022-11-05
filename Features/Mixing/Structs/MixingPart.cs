using Birdhouse.Features.Mixing.Interfaces;

namespace Birdhouse.Features.Mixing.Structs
{
    public readonly struct MixingPart<T> : IMixingPart<T>
    {
        public MixingPart(T value, float proportion)
        {
            Value = value;
            Proportion = proportion;
        }

        public T Value
        {
            get;
        }

        public float Proportion
        {
            get;
        }
    }
}