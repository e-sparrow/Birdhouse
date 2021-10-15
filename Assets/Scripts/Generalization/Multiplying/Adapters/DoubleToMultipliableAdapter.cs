using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Multiplying.Interfaces;

namespace ESparrow.Utils.Generalization.Multiplying
{
    public class DoubleToMultipliableAdapter : ToMultipliableAdapterBase<double>
    {
        public DoubleToMultipliableAdapter(double value) : base(value)
        {
            
        }

        public override IMultipliable<double> Multiply(double other)
        {
            return new DoubleToMultipliableAdapter(Value * other);
        }

        public override IMultipliable<double> Divide(double other)
        {
            return new DoubleToMultipliableAdapter(Value / other);
        }

        public override IMultipliable<double> Mod(double other)
        {
            return new DoubleToMultipliableAdapter(Value % other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Double;
    }
}