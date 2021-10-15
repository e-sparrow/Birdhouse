using ESparrow.Utils.Generalization.Multiplying.Interfaces;

namespace ESparrow.Utils.Generalization.Multiplying
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
    }
}