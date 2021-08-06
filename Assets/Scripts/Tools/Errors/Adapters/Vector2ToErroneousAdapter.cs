using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.Errors.Adapters
{
    public class Vector2ToErroneousAdapter : ToErroneousAdapterBase<Vector2>
    {
        public override Vector2 DefaultError => new Vector2(float.Epsilon, float.Epsilon);

        public Vector2ToErroneousAdapter(Vector2 value) : base(value)
        {

        }

        public override bool CompareWithError(Vector2 self, Vector2 other, Vector2 error)
        {
            bool x = Math.Abs(other.x - self.x) <= error.x;
            bool y = Math.Abs(other.y - self.y) <= error.y;

            return x && y;
        }
    }
}
