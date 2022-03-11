﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums
{
    public class AsyncPendulum : AsyncPendulumBase
    {
        public AsyncPendulum(TimeSpan period) : base(period)
        {
            
        }

        public AsyncPendulum(float seconds) : this(TimeSpan.FromSeconds(seconds))
        {
            
        }

        protected override async Task Wait(TimeSpan period, CancellationToken token)
        {
            await Task.Delay(period, token);
        }
    }
}