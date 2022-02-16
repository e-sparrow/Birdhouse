using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Generalization.Summation.Adapters
{
    public class DoubleToSummableAdapter : ToSummableAdapterBase<double>
    {
        public DoubleToSummableAdapter(double value) : base(value)
        {
            
        }

        public override ISummable<double> Plus(double other)
        {
            return new DoubleToSummableAdapter(Value + other);
        }
        
        public override ISummable<double> Minus(double other)
        {
            return new DoubleToSummableAdapter(Value - other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Double;
    }
}