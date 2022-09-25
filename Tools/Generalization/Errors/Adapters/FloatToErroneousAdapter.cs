using System;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Errors.Adapters
{
    public class FloatToErroneousAdapter : ToErroneousAdapterBase<float>
    {
        public override float DefaultError => float.Epsilon;

        public FloatToErroneousAdapter(float value) : base(value)
        {

        }

        protected override bool CompareWithError(float self, float other, float error)
        {
            return Math.Abs(other - self) <= error;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Float;
    }
}
