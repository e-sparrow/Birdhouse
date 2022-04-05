using UnityEngine;

namespace ESparrow.Utils.Inputs.Pressures
{
    public class MousePressureStateProvider : PressureStateProviderBase<int>
    {
        protected override bool IsPressed(int pressure)
        {
            return Input.GetMouseButtonDown(pressure);
        }

        protected override bool IsHolden(int pressure)
        {
            return Input.GetMouseButton(pressure);
        }

        protected override bool IsReleased(int pressure)
        {
            return Input.GetMouseButtonUp(pressure);
        }
    }
}