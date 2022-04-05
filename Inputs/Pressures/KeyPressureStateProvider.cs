using UnityEngine;

namespace ESparrow.Utils.Inputs.Pressures
{
    public class KeyPressureStateProvider : PressureStateProviderBase<KeyCode>
    {
        protected override bool IsPressed(KeyCode pressure)
        {
            return Input.GetKeyDown(pressure);
        }

        protected override bool IsHolden(KeyCode pressure)
        {
            return Input.GetKey(pressure);
        }

        protected override bool IsReleased(KeyCode pressure)
        {
            return Input.GetKeyUp(pressure);
        }
    }
}