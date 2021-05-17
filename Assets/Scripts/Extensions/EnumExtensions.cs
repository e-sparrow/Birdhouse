using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static EKeyState GetKeyState(this KeyCode key)
        {
            return KeysHelper.GetKeyState(key);
        }

        public static bool IsKeyAtState(this KeyCode key, EKeyState state)
        {
            return key.GetKeyState() == state;
        }
    }
}
