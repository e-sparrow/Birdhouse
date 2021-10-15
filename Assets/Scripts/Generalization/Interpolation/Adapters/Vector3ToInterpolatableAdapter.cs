using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class Vector3ToInterpolatableAdapter : ToInterpolatableAdapterBase<Vector3>
    {
        public Vector3ToInterpolatableAdapter(Reference<Vector3> value) : base(value)
        {

        }

        public override void Interpolate(Vector3 from, Vector3 to, float progress)
        {
            Value = Vector3.Lerp(from, to, progress);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector3;
    }
}
