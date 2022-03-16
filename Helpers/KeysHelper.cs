using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Helpers
{
    public static class KeysHelper
    {
        public static EKeyState GetKeyState(KeyCode key)
        {
            if (Input.GetKeyDown(key))
            {
                return EKeyState.Pressed;
            }
            else if (Input.GetKey(key))
            {
                return EKeyState.Holded;
            }
            else if (Input.GetKeyUp(key))
            {
                return EKeyState.Released;
            }
            else
            {
                return EKeyState.Untouched;
            }
        }

        public static IEnumerable<KeyCode> GetKeysWithState(EKeyState state)
        {
            var values = (KeyCode[])typeof(KeyCode).GetEnumValues();
            return values.Where(Predicate).AsEnumerable();

            bool Predicate(KeyCode key)
            {
                return GetKeyState(key) == state;
            }
        }
    }
}
