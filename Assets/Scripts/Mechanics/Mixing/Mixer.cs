using ESparrow.Utils.Tools.Interpolation.Interfaces;
using ESparrow.Utils.Tools.Interpolation.Mixing.Interfaces;
using ESparrow.Utils.Mechanics.Mixing.Structs;

namespace ESparrow.Utils.Mechanics.Mixing
{
    public class Mixer<T> : MixerBase<T>
    {
        public Mixer(IInterpolator<T> interpolator) : base(interpolator)
        {
            
        }

        protected override IMixingPart<T> Mix(IInterpolator<T> interpolator, IMixingPart<T> first, IMixingPart<T> second)
        {
            var summary = first.Proportion + second.Proportion;
                
            var value = interpolator.Interpolate(first.Value, second.Value, first.Proportion / summary);
            var proportion = first.Proportion + second.Proportion;
                
            return new MixingPart<T>(value, proportion);
        }
    }
}