using System;

namespace Birdhouse.Features.FluentLogics
{
    public static class FluentLogicsExtensions
    {
        public static SoHandler So(this bool self, Action action)
        {
            var root = new LogicRoot(() => self);

            var result = root.So(action);
            return result;
        }

        public static SoHandler So(this Func<bool> self, Action action)
        {
            var root = new LogicRoot(self);

            var result = root.So(action);
            return result;
        }

        public static SoHandler<T> SoReturn<T>(this bool self, T value)
        {
            var root = new LogicRoot<T>(() => self);
            
            var result = root.SoReturn(() => value);
            return result;
        }

        public static SoHandler<T> SoReturn<T>(this Func<bool> self, T value)
        {
            var root = new LogicRoot<T>(self);

            var result = root.SoReturn(() => value);
            return result;
        }

        public static SoHandler<T> SoReturn<T>(this bool self, Func<T> value)
        {
            var root = new LogicRoot<T>(() => self);
            
            var result = root.SoReturn(value);
            return result;
        }

        public static SoHandler<T> SoReturn<T>(this Func<bool> self, Func<T> value)
        {
            var root = new LogicRoot<T>(self);

            var result = root.SoReturn(value);
            return result;
        }
    }
}