using UnityEngine;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public class MousePressureStateProvider : PressureStateProviderBase<int>
    {
        protected override bool IsPressed(int pressure)
        {
            var result = Input.GetMouseButtonDown(pressure);
            return result;
        }

        protected override bool IsHolden(int pressure)
        {
            var result = Input.GetMouseButton(pressure);
            return result;
        }

        protected override bool IsReleased(int pressure)
        {
            var result = Input.GetMouseButtonUp(pressure);
            return result;
        }
    }
}