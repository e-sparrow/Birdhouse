using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.Errors.Adapters
{
    public class ColorToErroneousAdapter : ToErroneousAdapterBase<Color>
    {
        public override Color DefaultError => new Color(float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon);

        public ColorToErroneousAdapter(Color value) : base(value)
        {

        }

        public override bool CompareWithError(Color self, Color other, Color error)
        {
            bool r = Math.Abs(other.r - self.r) <= error.r;
            bool g = Math.Abs(other.g - self.g) <= error.g;
            bool b = Math.Abs(other.b - self.b) <= error.b;
            bool a = Math.Abs(other.a - self.a) <= error.a;

            return r && g && b && a;
        }
    }
}
