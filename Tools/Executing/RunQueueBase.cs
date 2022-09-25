using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Tools.Executing.Interfaces;

namespace Birdhouse.Tools.Executing
{
    public abstract class RunQueueBase : IRunQueue
    {
        protected abstract bool Any();
        protected abstract Action Dequeue();
        
        protected abstract void Fill();
        protected abstract void Update();

        public void Next()
        {
            if (!Any())
            {
                Fill();
            }
            else
            {
                var action = Dequeue();
                action.Invoke();

                Update();
            }
        }
    }
}