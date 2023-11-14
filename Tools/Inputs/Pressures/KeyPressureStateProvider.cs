using UnityEngine;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public class KeyPressureStateProvider 
        : PressureStateProviderBase<KeyCode>
    {
        protected override bool IsPressed(KeyCode pressure)
        {
            var result = Input.GetKeyDown(pressure);
            return result;
        }

        protected override bool IsHeld(KeyCode pressure)
        {
            var result = Input.GetKey(pressure);
            return result;
        }

        protected override bool IsReleased(KeyCode pressure)
        {
            var result = Input.GetKeyUp(pressure);
            return result;
        }
    }
}