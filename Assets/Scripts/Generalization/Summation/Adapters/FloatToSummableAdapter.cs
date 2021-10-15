using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Generalization.Summation.Adapters
{
    public class FloatToSummableAdapter : ToSummableAdapterBase<float>
    {
        public FloatToSummableAdapter(float value) : base(value)
        {
            
        }

        public override ISummable<float> Plus(float other)
        {
            return new FloatToSummableAdapter(Value + other);
        }

        public override ISummable<float> Minus(float other)
        {
            return new FloatToSummableAdapter(Value - other);
        }
    }
}