using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentSwitchExtensions
    {
        public static SwitchRoot<T> Switch<T>(this T self) => FluentSwitch.Switch(self);
        public static SwitchRoot<TIn, TOut> Switch<TIn, TOut>(this TIn self) => FluentSwitch.Switch<TIn, TOut>(self);

        public static CaseHandler<T> Case<T>(this SwitchRoot<T> self, T value) => self.Case(item => item.Equals(value));
        public static CaseHandler<T> Case<T>(this SwitchSoHandler<T> self, T value) => self.Case(item => item.Equals(value));

        public static CaseHandler<TIn, TOut> Case<TIn, TOut>(this SwitchRoot<TIn, TOut> self, TIn value) => self.Case(item => item.Equals(value));
        public static CaseHandler<TIn, TOut> Case<TIn, TOut>(this SwitchSoHandler<TIn, TOut> self, TIn value) => self.Case(item => item.Equals(value));
        public static SwitchSoHandler<TIn, TOut> So<TIn, TOut>(this CaseHandler<TIn, TOut> self, TOut value) => self.So(() => value);
        public static TOut Default<TIn, TOut>(this SwitchSoHandler<TIn, TOut> self, TOut value) => self.Default(() => value);
    }
}