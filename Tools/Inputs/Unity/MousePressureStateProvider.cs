using Birdhouse.Tools.Inputs.Pressures;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public class MousePressureStateProvider 
        : PressureStateProviderBase<int>
    {
        protected override bool IsPressed(int key)
        {
            var result = Input.GetMouseButtonDown(key);
            return result;
        }

        protected override bool IsHeld(int key)
        {
            var result = Input.GetMouseButton(key);
            return result;
        }

        protected override bool IsReleased(int key)
        {
            var result = Input.GetMouseButtonUp(key);
            return result;
        }
    }
}