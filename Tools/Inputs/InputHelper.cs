using Birdhouse.Tools.Inputs.Pressures;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Helpers
{
    public static class InputHelper
    {
        static InputHelper()
        {
            KeyPressureStateProvider = new KeyPressureStateProvider();
            ButtonPressureStateProvider = new ButtonPressureStateProvider();
            MousePressureStateProvider = new MousePressureStateProvider();
        }
        
        public static IPressureStateProvider<KeyCode> KeyPressureStateProvider
        {
            get;
        }

        public static IPressureStateProvider<string> ButtonPressureStateProvider
        {
            get;
        }

        public static IPressureStateProvider<int> MousePressureStateProvider
        {
            get;
        }
    }
}
