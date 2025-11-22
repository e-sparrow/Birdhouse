using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentBranching
    {
        public static BranchingRoot If(bool value) => new BranchingRoot(() => value);
        public static BranchingRoot If(Func<bool> func) => new BranchingRoot(func);
    }

    public static class FluentBranching<T>
    {
        public static BranchingRoot<T> If(bool value) => new BranchingRoot<T>(() => value);
        public static BranchingRoot<T> If(Func<bool> condition) => new BranchingRoot<T>(condition);
    }

    public static class FluentSwitch
    {
        public static SwitchRoot<T> Switch<T>(T value) => new SwitchRoot<T>(value);
        public static SwitchRoot<TIn, TOut> Switch<TIn, TOut>(TIn value) => new SwitchRoot<TIn, TOut>(value);
    }
}