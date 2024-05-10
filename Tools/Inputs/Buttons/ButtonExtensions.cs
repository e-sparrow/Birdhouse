using Birdhouse.Tools.Inputs.Buttons.Abstractions;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Buttons
{
    public static class ButtonExtensions
    {
        public static IButtonService<TButton> AsButtonService<TButton>(this IPressureStateProvider<TButton> self)
        {
            var result = new PressureStateProviderToButtonServiceAdapter<TButton>(self);
            return result;
        }
    }
}