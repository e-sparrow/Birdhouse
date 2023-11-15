using Birdhouse.Tools.Inputs.Pressures;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public class KeyCodePressureStateProvider 
        : PressureStateProviderBase<KeyCode>
    {
        protected override bool IsPressed(KeyCode key)
        {
            var result = Input.GetKeyDown(key);
            return result;
        }

        protected override bool IsHeld(KeyCode key)
        {
            var result = Input.GetKey(key);
            return result;
        }

        protected override bool IsReleased(KeyCode key)
        {
            var result = Input.GetKeyUp(key);
            return result;
        }
    }
}