using Birdhouse.Tools.Inputs.Buttons.Abstractions;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Buttons
{
    public sealed class PressureStateProviderToButtonServiceAdapter<TButton>
        : IButtonService<TButton>
    {
        public PressureStateProviderToButtonServiceAdapter(IPressureStateProvider<TButton> inner)
        {
            _inner = inner;
        }

        private readonly IPressureStateProvider<TButton> _inner;

        public bool GetButtonDown(TButton button)
        {
            var result = _inner.GetPressureState(button) == EPressureState.Pressed;
            return result;
        }

        public bool GetButton(TButton button)
        {
            var result = _inner.GetPressureState(button) == EPressureState.Holden;
            return result;
        }

        public bool GetButtonUp(TButton button)
        {
            var result = _inner.GetPressureState(button) == EPressureState.Released;
            return result;
        }
    }
}