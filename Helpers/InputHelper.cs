using ESparrow.Utils.Inputs.Pressures;
using ESparrow.Utils.Inputs.Pressures.Enums;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Helpers
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
