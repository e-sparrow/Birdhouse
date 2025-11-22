using System;
using System.Collections.Generic;
using System.Linq;

namespace Birdhouse.Experimental.FluentLogics
{
    public class BranchingRoot
    {
        public BranchingRoot(Func<bool> func)
        {
            _func = func;
            _constructions = new List<BranchingConstruction>();
        }

        private readonly Func<bool> _func;
        private readonly IList<BranchingConstruction> _constructions;

        public void Add(BranchingConstruction construction) => _constructions.Add(construction);
        
        public void Execute(Action elseAction)
        {
            if (_constructions.Any(construction => construction.Check())) return;
            elseAction.Invoke();
        }
 
        public BranchingSoHandler So(Action action)
        {
            var construction = new BranchingConstruction(_func, action);
            Add(construction);

            var handler = new BranchingSoHandler(this);
            return handler;
        }
    }

    public class BranchingRoot<T>
    {
        public BranchingRoot(Func<bool> condition)
        {
            _condition = condition;
            _constructions = new List<ConditionConstruction<T>>();
        }
        
        private readonly Func<bool> _condition;
        private readonly IList<ConditionConstruction<T>> _constructions;

        public void Add(ConditionConstruction<T> construction) => _constructions.Add(construction);

        public T Execute(Func<T> elseFunc)
        {
            foreach (var construction in _constructions)
                if (construction.Check(out var value))
                    return value;
                
            var result = elseFunc.Invoke();
            return result;
        }

        public BranchingSoHandler<T> SoReturn(Func<T> func)
        {
            var construction = new ConditionConstruction<T>(_condition, func);
            Add(construction);

            var handler = new BranchingSoHandler<T>(this);
            return handler;
        }
    }
}