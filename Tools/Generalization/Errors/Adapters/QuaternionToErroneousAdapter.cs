using System;
using Birdhouse.Tools.Generalization.Types.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Generalization.Errors.Adapters
{
    public class QuaternionToErroneousAdapter : ToErroneousAdapterBase<Quaternion>
    {
        public override Quaternion DefaultError => Quaternion.Euler(float.Epsilon, float.Epsilon, float.Epsilon);

        public QuaternionToErroneousAdapter(Quaternion value) : base(value)
        {

        }

        protected override bool CompareWithError(Quaternion self, Quaternion other, Quaternion error)
        {
            bool x = Math.Abs(other.x - self.x) <= error.x;
            bool y = Math.Abs(other.y - self.y) <= error.y;
            bool z = Math.Abs(other.z - self.z) <= error.z;
            bool w = Math.Abs(other.w - self.w) <= error.w;

            return x && y && z && w;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Quaternion;
    }
}
