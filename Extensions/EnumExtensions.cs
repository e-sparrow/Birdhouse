using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets state of the specified key.
        /// </summary>
        /// <param name="key">Specified key</param>
        /// <returns>State of the key</returns>
        public static EKeyState GetKeyState(this KeyCode key)
        {
            return KeysHelper.GetKeyState(key);
        }

        /// <summary>
        /// Is key in a specified state.
        /// </summary>
        /// <param name="key">KeyCode to check</param>
        /// <param name="state">State to check</param>
        /// <returns>True if key is in specified state and false otherwise</returns>
        public static bool IsKeyAtState(this KeyCode key, EKeyState state)
        {
            return key.GetKeyState() == state;
        }
    }
}
