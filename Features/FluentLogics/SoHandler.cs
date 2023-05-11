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
}