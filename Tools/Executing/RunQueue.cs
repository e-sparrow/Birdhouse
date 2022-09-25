using System;
using System.Collections.Generic;
using System.Linq;

namespace Birdhouse.Tools.Executing
{
    public class RunQueue : RunQueueBase
    {
        public RunQueue(IEnumerable<Action> source, Func<Action> creator)
        {
            _source = source;
            _creator = creator;
        }

        private readonly IEnumerable<Action> _source;
        private readonly Func<Action> _creator;

        private readonly Queue<Action> _queue = new Queue<Action>();

        protected override bool Any()
        {
            return _queue.Any();
        }

        protected override Action Dequeue()
        {
            return _queue.Dequeue();
        }

        protected override void Fill()
        {
            foreach (var item in _source)
            {
                _queue.Enqueue(item);
            }
        }

        protected override void Update()
        {
            var item = _creator.Invoke();
            _queue.Enqueue(item);
        }
    }
}