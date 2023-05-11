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
}