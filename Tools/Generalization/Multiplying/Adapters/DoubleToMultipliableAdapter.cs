using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
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