using System;

namespace Birdhouse.Tools.Ticks.Unity
{
    public class UnityTickProvider 
        : UnityTickProviderBase
    {
        public UnityTickProvider(Func<float> func, Type subsystemType) 
            : base(subsystemType)
        {
            _func = func;
        }

        private readonly Func<float> _func;

        protected override float GetDeltaTime()
        {
            var result = _func.Invoke();
            return result;
        }
    }
}