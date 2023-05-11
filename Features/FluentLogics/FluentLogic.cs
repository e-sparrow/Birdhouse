using System;

namespace Birdhouse.Features.FluentLogics
{
    public static class FluentLogic
    {
        public static LogicRoot If(Func<bool> func)
        {
            var root = new LogicRoot(func);
            return root;
        }
    }
}