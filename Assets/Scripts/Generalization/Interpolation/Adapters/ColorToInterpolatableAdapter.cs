using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class ColorToInterpolatableAdapter : ToInterpolatableAdapterBase<Color>
    {
        public ColorToInterpolatableAdapter(Reference<Color> reference) : base(reference)
        {

        }

        public override void Interpolate(Color from, Color to, float progress)
        {
            Value = Color.Lerp(from, to, progress);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Color;
    }
}
