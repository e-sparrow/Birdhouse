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

    public static class FluentLogic<T>
    {
        public static LogicRoot<T> If(Func<bool> condition)
        {
            var root = new LogicRoot<T>(condition);
            return root;
        }
    }
}