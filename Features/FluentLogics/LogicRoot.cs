using System;
using System.Collections.Generic;

namespace Birdhouse.Features.FluentLogics
{
    public readonly struct LogicRoot
    {
        public LogicRoot(Func<bool> func)
        {
            _func = func;
            _constructions = new List<ConditionConstruction>();
        }

        private readonly Func<bool> _func;
        
        private readonly IList<ConditionConstruction> _constructions;

        public void Add(ConditionConstruction construction)
        {
            _constructions.Add(construction);
        }

        public void Execute(Action elseAction)
        {
            foreach (var construction in _constructions)
            {
                if (construction.Check())
                {
                    return;
                }
            }
            
            elseAction.Invoke();
        }

        public SoHandler So(Action action)
        {
            var construction = new ConditionConstruction(_func, action);
            Add(construction);

            var handler = new SoHandler(this);
            return handler;
        }
    }
}