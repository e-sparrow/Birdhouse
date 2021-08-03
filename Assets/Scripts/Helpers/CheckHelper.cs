using System;

namespace ESparrow.Utils.Helpers
{
    public static class CheckHelper 
    {
        public static Action CheckForDefault(Action action)
        {
            if (action == default)
            {
                return () => { };
            }
            else
            {
                return action;
            }
        }
    }
}
