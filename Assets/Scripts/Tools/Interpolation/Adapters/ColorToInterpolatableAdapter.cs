using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class ColorToInterpolatableAdapter : ToInterpolatableAdapterBase<Color>
    {
        public ColorToInterpolatableAdapter(Reference<Color> reference) : base(reference)
        {

        }

        public override void Interpolate(Color from, Color to, float t)
        {
            Value = Color.Lerp(from, to, t);
        }
    }
}
