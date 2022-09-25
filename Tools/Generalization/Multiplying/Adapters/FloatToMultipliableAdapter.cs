using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
{
    public class FloatToMultipliableAdapter : ToMultipliableAdapterBase<float>
    {
        public FloatToMultipliableAdapter(float value) : base(value)
        {
            
        }

        public override IMultipliable<float> Multiply(float other)
        {
            return new FloatToMultipliableAdapter(Value * other);
        }

        public override IMultipliable<float> Divide(float other)
        {
            return new FloatToMultipliableAdapter(Value / other);
        }

        public override IMultipliable<float> Mod(float other)
        {
            return new FloatToMultipliableAdapter(Value % other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Float;
    }
}