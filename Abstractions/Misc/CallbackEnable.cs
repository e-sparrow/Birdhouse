using System;

namespace Birdhouse.Abstractions.Misc
{
    public sealed class CallbackEnable
        : IEnable
    {
        public CallbackEnable(Action<bool> callback)
        {
            _callback = callback;
        }

        private readonly Action<bool> _callback;

        public bool IsEnabled
        {
            get;
            private set;
        }
        
        public void SetEnabled(bool isEnabled)
        {
            IsEnabled = isEnabled;
            _callback.Invoke(isEnabled);
        }
    }
}