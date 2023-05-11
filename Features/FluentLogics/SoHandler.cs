using System;

namespace Birdhouse.Features.FluentLogics
{
    public readonly struct SoHandler
    {
        public SoHandler(LogicRoot root)
        {
            _root = root;
        }

        private readonly LogicRoot _root;
        
        public ElseIfHandler ElseIf(Func<bool> func)
        {
            var handler = new ElseIfHandler(_root, func);
            return handler;
        }

        public ElseHandler Else()
        {
            var handler = new ElseHandler(_root);
            return handler;
        }
    }

    public readonly struct SoHandler<T>
    {
        public SoHandler(LogicRoot<T> root)
        {
            _root = root;
        }

        private readonly LogicRoot<T> _root;
        
        public ElseIfHandler<T> ElseIf(Func<bool> func)
        {
            var handler = new ElseIfHandler<T>(_root, func);
            return handler;
        }

        public ElseHandler<T> Else()
        {
            var handler = new ElseHandler<T>(_root);
            return handler;
        }
    }
}