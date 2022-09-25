using Birdhouse.Tools.Generalization.Summation.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Summation.Adapters
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

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Float;
    }
}