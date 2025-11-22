using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct ElseIfHandler
    {
        public ElseIfHandler(BranchingRoot root, Func<bool> condition)
        {
            _root = root;
            _condition = condition;
        }

        private readonly BranchingRoot _root;
        private readonly Func<bool> _condition;

        public BranchingSoHandler So(Action action)
        {
            var construction = new BranchingConstruction(_condition, action);
            _root.Add(construction);

            var handler = new BranchingSoHandler(_root);
            return handler;
        }
    }
    
    public readonly struct ElseIfHandler<T>
    {
        public ElseIfHandler(BranchingRoot<T> root, Func<bool> condition)
        {
            _root = root;
            _condition = condition;
        }

        private readonly BranchingRoot<T> _root;
        private readonly Func<bool> _condition;

        public BranchingSoHandler<T> SoReturn(Func<T> func)
        {
            var construction = new ConditionConstruction<T>(_condition, func);
            _root.Add(construction);

            var handler = new BranchingSoHandler<T>(_root);
            return handler;
        }
    }
}