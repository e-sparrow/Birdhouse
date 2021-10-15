using System;
using ESparrow.Utils.Generalization.Types.Enums;

namespace ESparrow.Utils.Generalization.Errors.Adapters
{
    public class DoubleToErroneousAdapter : ToErroneousAdapterBase<double>
    {
        public override double DefaultError => double.Epsilon;

        public DoubleToErroneousAdapter(double value) : base(value)
        {

        }

        protected override bool CompareWithError(double self, double other, double error)
        {
            return Math.Abs(other - self) <= error;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Double;
    }
}
