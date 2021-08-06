using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.Errors.Adapters
{
    public class QuaternionToErroneousAdapter : ToErroneousAdapterBase<Quaternion>
    {
        public override Quaternion DefaultError => Quaternion.Euler(float.Epsilon, float.Epsilon, float.Epsilon);

        public QuaternionToErroneousAdapter(Quaternion value) : base(value)
        {

        }

        public override bool CompareWithError(Quaternion self, Quaternion other, Quaternion error)
        {
            bool x = Math.Abs(other.x - self.x) <= error.x;
            bool y = Math.Abs(other.y - self.y) <= error.y;
            bool z = Math.Abs(other.z - self.z) <= error.z;
            bool w = Math.Abs(other.w - self.w) <= error.w;

            return x && y && z && w;
        }
    }
}
