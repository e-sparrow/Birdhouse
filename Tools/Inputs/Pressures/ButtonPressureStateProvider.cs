using UnityEngine;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public class ButtonPressureStateProvider 
        : PressureStateProviderBase<string>
    {
        protected override bool IsPressed(string pressure)
        {
            var result = Input.GetButtonDown(pressure);
            return result;
        }

        protected override bool IsHolden(string pressure)
        {
            var result = Input.GetButton(pressure);
            return result;
        }

        protected override bool IsReleased(string pressure)
        {
            var result = Input.GetButtonUp(pressure);
            return result;
        }
    }
}