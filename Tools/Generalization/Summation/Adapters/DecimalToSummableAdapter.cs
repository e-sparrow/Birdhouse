using Birdhouse.Tools.Generalization.Summation.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Summation.Adapters
{
    public class DecimalToSummableAdapter : ToSummableAdapterBase<decimal>
    {
        public DecimalToSummableAdapter(decimal value) : base(value)
        {
            
        }

        public override ISummable<decimal> Plus(decimal other)
        {
            return new DecimalToSummableAdapter(Value + other);
        }
        
        public override ISummable<decimal> Minus(decimal other)
        {
            return new DecimalToSummableAdapter(Value - other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Decimal;
    }
}