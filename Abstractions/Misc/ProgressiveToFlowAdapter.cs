using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Ticks;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Abstractions.Misc
{
    public class ProgressiveToFlowAdapter
        : TickFlowBase
    {
        public ProgressiveToFlowAdapter
        (
            IProgressive progressive, 
            ITickProvider tickProvider, 
            Func<float> speedFunc = null
        )
        {
            speedFunc ??= 1f.AsFunc();
            
            _progressive = progressive;
            _tickProvider = tickProvider;
            _speedFunc = speedFunc;
        }

        private readonly IProgressive _progressive;
        private readonly ITickProvider _tickProvider;
        private readonly Func<float> _speedFunc;

        protected override ITickProvider GetTickProvider()
        {
            return _tickProvider;
        }

        protected override void Tick(float deltaTime)
        {
            _progressive.Progress += deltaTime * _speedFunc.Invoke();
        }
    }
}