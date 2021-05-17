using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Listeners
{
    public class PressListener : MonoBehaviour
    {
        public event Action<KeyCode> OnAnyKeyPressed;

        public bool IsActive
        {
            get;
            private set;
        }

        public void SetActive(bool active)
        {
            IsActive = active;
        }

        private void Update()
        {
            if (IsActive)
            {
                foreach (var key in KeysHelper.GetKeysWithState(EKeyState.Pressed))
                {
                    OnAnyKeyPressed?.Invoke(key);
                }
            }
        }
    }
}
