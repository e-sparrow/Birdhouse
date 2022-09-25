using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
{
    public class DecimalToMultipliableAdapter : ToMultipliableAdapterBase<decimal>
    {
        public DecimalToMultipliableAdapter(decimal value) : base(value)
        {
            
        }

        public override IMultipliable<decimal> Multiply(decimal other)
        {
            return new DecimalToMultipliableAdapter(Value * other);
        }

        public override IMultipliable<decimal> Divide(decimal other)
        {
            return new DecimalToMultipliableAdapter(Value / other);
        }

        public override IMultipliable<decimal> Mod(decimal other)
        {
            return new DecimalToMultipliableAdapter(Value % other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Decimal;
    }
}
