using UnityEngine;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public class ButtonPressureStateProvider : PressureStateProviderBase<string>
    {
        protected override bool IsPressed(string pressure)
        {
            return Input.GetButtonDown(pressure);
        }

        protected override bool IsHolden(string pressure)
        {
            return Input.GetButton(pressure);
        }

        protected override bool IsReleased(string pressure)
        {
            return Input.GetButtonUp(pressure);
        }
    }
}