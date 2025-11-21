using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentLogic
    {
        public static BranchingRoot If(bool value) => new BranchingRoot(() => value);
        public static BranchingRoot If(Func<bool> func) => new BranchingRoot(func);
        public static SwitchRoot<T> Switch<T>(T value) => new SwitchRoot<T>(value);
    }

    public static class FluentLogic<T>
    {
        public static BranchingRoot<T> If(bool value) => new BranchingRoot<T>(() => value);
        public static BranchingRoot<T> If(Func<bool> condition) => new BranchingRoot<T>(condition);
    }
}