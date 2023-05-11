using System;

namespace Birdhouse.Features.FluentLogics
{
    public readonly struct ElseIfHandler
    {
        public ElseIfHandler(LogicRoot root, Func<bool> func)
        {
            _root = root;
            _func = func;
        }

        private readonly LogicRoot _root;
        private readonly Func<bool> _func;

        public SoHandler So(Action action)
        {
            var construction = new ConditionConstruction(_func, action);
            _root.Add(construction);

            var handler = new SoHandler(_root);
            return handler;
        }
    }
}