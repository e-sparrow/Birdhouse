using System;
using System.Collections.Generic;

namespace Birdhouse.Features.FluentLogics
{
    public class LogicRoot
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

    public class LogicRoot<T>
    {
        public LogicRoot(Func<bool> condition)
        {
            _condition = condition;
            _constructions = new List<ConditionConstruction<T>>();
        }
        
        private readonly Func<bool> _condition;
        private readonly IList<ConditionConstruction<T>> _constructions;

        public void Add(ConditionConstruction<T> construction)
        {
            _constructions.Add(construction);
        }

        public T Execute(Func<T> elseFunc)
        {
            foreach (var construction in _constructions)
            {
                if (construction.Check(out var value))
                {
                    return value;
                }
            }

            var result = elseFunc.Invoke();
            return result;
        }

        public SoHandler<T> SoReturn(Func<T> func)
        {
            var construction = new ConditionConstruction<T>(_condition, func);
            Add(construction);

            var handler = new SoHandler<T>(this);
            return handler;
        }
    }
}