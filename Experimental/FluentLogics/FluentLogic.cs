using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentLogic
    {
        public static LogicRoot If(bool value)
        {
            var root = new LogicRoot(() => value);
            return root;
        }
        
        public static LogicRoot If(Func<bool> func)
        {
            var root = new LogicRoot(func);
            return root;
        }
    }

    public static class FluentLogic<T>
    {
        public static LogicRoot<T> If(bool value)
        {
            var root = new LogicRoot<T>(() => value);
            return root;
        }
        public static LogicRoot<T> If(Func<bool> condition)
        {
            var root = new LogicRoot<T>(condition);
            return root;
        }
    }
}