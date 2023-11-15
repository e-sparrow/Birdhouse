using Birdhouse.Tools.Inputs.Pressures;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public class ButtonPressureStateProvider 
        : PressureStateProviderBase<string>
    {
        protected override bool IsPressed(string key)
        {
            var result = Input.GetButtonDown(key);
            return result;
        }

        protected override bool IsHeld(string key)
        {
            var result = Input.GetButton(key);
            return result;
        }

        protected override bool IsReleased(string key)
        {
            var result = Input.GetButtonUp(key);
            return result;
        }
    }
}