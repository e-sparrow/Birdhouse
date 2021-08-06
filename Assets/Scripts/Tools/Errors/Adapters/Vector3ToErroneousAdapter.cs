using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.Errors.Adapters
{
    public class Vector3ToErroneousAdapter : ToErroneousAdapterBase<Vector3>
    {
        public override Vector3 DefaultError => new Vector3(float.Epsilon, float.Epsilon, float.Epsilon);

        public Vector3ToErroneousAdapter(Vector3 value) : base(value)
        {

        }

        public override bool CompareWithError(Vector3 self, Vector3 other, Vector3 error)
        {
            bool x = Math.Abs(other.x - self.x) <= error.x;
            bool y = Math.Abs(other.y - self.y) <= error.y;
            bool z = Math.Abs(other.z - self.z) <= error.z;

            return x && y && z;
        }
    }
}
