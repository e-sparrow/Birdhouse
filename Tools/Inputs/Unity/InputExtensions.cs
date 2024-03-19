using Birdhouse.Tools.Inputs.Pressures.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public static class InputExtensions
    {
        /// <summary>
        /// Gets state of the specified key.
        /// </summary>
        /// <param name="key">Specified key</param>
        /// <returns>State of the key</returns>
        public static EPressureState GetKeyState(this KeyCode key)
        {
            return UnityInputHelper
                .KeyCodeStateProvider
                .Value
                .GetPressureState(key);
        }
        
        /// <summary>
        /// Is key in a specified state.
        /// </summary>
        /// <param name="key">KeyCode to check</param>
        /// <param name="state">State to check</param>
        /// <returns>True if key is in specified state and false otherwise</returns>
        public static bool IsKeyAtState(this KeyCode key, EPressureState state)
        {
            return key.GetKeyState() == state;
        }
    }
}