using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Managers;

namespace ESparrow.Utils.Listeners
{
    public class PressListener
    {
        public PressListener()
        {
            UnityMessagesManager.Instance.UpdateHandler += Check;
        }

        public event Action<KeyCode> OnAnyKeyPressed;

        private void Check()
        {
            foreach (var key in KeysHelper.GetKeysWithState(EKeyState.Pressed))
            {
                OnAnyKeyPressed?.Invoke(key);
            }
        }
    }
}
