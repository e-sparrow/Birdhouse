using System;

namespace Birdhouse.Features.FluentLogics
{
    public readonly struct ElseHandler
    {
        public ElseHandler(LogicRoot root)
        {
            _root = root;
        }

        private readonly LogicRoot _root;

        public void So(Action action)
        {
            _root.Execute(action);
        }
    }
    
    public readonly struct ElseHandler<T>
    {
        public ElseHandler(LogicRoot<T> root)
        {
            _root = root;
        }

        private readonly LogicRoot<T> _root;

        public T SoReturn(Func<T> func)
        {
            var result = _root.Execute(func);
            return result;
        }
    }
}