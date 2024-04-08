using System;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentLogicExtensions
    {
        public static SoHandler So(this bool self, Action action)
        {
            var result = new LogicRoot(() => self)
                .So(action);
            
            return result;
        }

        public static SoHandler So(this Func<bool> self, Action action)
        {
            var result = new LogicRoot(self)
                .So(action);
            
            return result;
        }

        public static SoHandler ThrowIfFalse(this Func<bool> self, Func<Exception> onFail = null)
        {
            onFail ??= () => new ArgumentException();

            var result = self.Reverse().So(FailHandler);
            return result;
            
            void FailHandler()
            {
                var exception = onFail.Invoke();
                throw exception;
            }
        }

        public static SoHandler ThrowIfFalse(this bool self, Func<Exception> onFail = null)
        {
            onFail ??= () => new ArgumentException();

            var result = (!self).So(FailHandler);
            return result;
            
            void FailHandler()
            {
                var exception = onFail.Invoke();
                throw exception;
            }
        }
    }
}