using System;

namespace Birdhouse.Common.Helpers
{
    public static class CheckHelper 
    {
        /// <summary>
        /// Checks self action for default.
        /// </summary>
        /// <param name="action">Self action</param>
        /// <returns>Returns empty action if action is default and self without changes otherwise</returns>
        public static Action CheckForDefault(Action action)
        {
            if (action == default)
            {
                return () => { };
            }

            return action;
        }
    }
}
