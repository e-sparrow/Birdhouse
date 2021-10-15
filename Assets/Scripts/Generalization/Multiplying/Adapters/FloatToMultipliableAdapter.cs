using ESparrow.Utils.Generalization.Multiplying.Interfaces;

namespace ESparrow.Utils.Generalization.Multiplying
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
    }
}