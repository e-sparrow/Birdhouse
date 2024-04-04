using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct ElseIfHandler
    {
        public ElseIfHandler(LogicRoot root, Func<bool> condition)
        {
            _root = root;
            _condition = condition;
        }

        private readonly LogicRoot _root;
        private readonly Func<bool> _condition;

        public SoHandler So(Action action)
        {
            var construction = new ConditionalConstruction(_condition, action);
            _root.Add(construction);

            var handler = new SoHandler(_root);
            return handler;
        }
    }
    
    public readonly struct ElseIfHandler<T>
    {
        public ElseIfHandler(LogicRoot<T> root, Func<bool> condition)
        {
            _root = root;
            _condition = condition;
        }

        private readonly LogicRoot<T> _root;
        private readonly Func<bool> _condition;

        public SoHandler<T> SoReturn(Func<T> func)
        {
            var construction = new ConditionConstruction<T>(_condition, func);
            _root.Add(construction);

            var handler = new SoHandler<T>(_root);
            return handler;
        }
    }
}