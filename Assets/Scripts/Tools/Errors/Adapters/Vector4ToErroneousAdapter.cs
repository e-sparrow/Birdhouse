using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.Errors.Adapters
{
    public class Vector4ToErroneousAdapter : ToErroneousAdapterBase<Vector4>
    {
        public override Vector4 DefaultError => new Vector4(float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon);

        public Vector4ToErroneousAdapter(Vector4 value) : base(value)
        {

        }

        public override bool CompareWithError(Vector4 self, Vector4 other, Vector4 error)
        {
            bool x = Math.Abs(other.x - self.x) <= error.x;
            bool y = Math.Abs(other.y - self.y) <= error.y;
            bool z = Math.Abs(other.z - self.z) <= error.z;
            bool w = Math.Abs(other.w - self.w) <= error.w;

            return x && y && z && w;
        }
    }
}
