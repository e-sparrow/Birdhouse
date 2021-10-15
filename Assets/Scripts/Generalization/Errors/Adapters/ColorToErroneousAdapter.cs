using System;
using ESparrow.Utils.Generalization.Types.Enums;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Errors.Adapters
{
    public class ColorToErroneousAdapter : ToErroneousAdapterBase<Color>
    {
        public override Color DefaultError => new Color(float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon);

        public ColorToErroneousAdapter(Color value) : base(value)
        {

        }

        protected override bool CompareWithError(Color self, Color other, Color error)
        {
            var r = Math.Abs(other.r - self.r) <= error.r;
            var g = Math.Abs(other.g - self.g) <= error.g;
            var b = Math.Abs(other.b - self.b) <= error.b;
            var a = Math.Abs(other.a - self.a) <= error.a;

            return r && g && b && a;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Color;
    }
}
