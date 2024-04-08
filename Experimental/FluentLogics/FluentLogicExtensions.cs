using System;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentLogicExtensions
    {
        public static SoHandler IfTrue(this bool self, Action action)
        {
            var result = new LogicRoot(() => self).So(action);
            return result;
        }

        public static SoHandler IfTrue(this Func<bool> self, Action action)
        {
            var result = new LogicRoot(self).So(action);
            return result;
        }
        
        public static SoHandler IfFalse(this bool self, Action action)
        {
            var result = new LogicRoot(() => !self).So(action);
            return result;
        }

        public static SoHandler IfFalse(this Func<bool> self, Action action)
        {
            var result = new LogicRoot(self.Reverse()).So(action);
            return result;
        }

        public static SoHandler ThrowIfTrue(this Func<bool> self, Func<Exception> onFail = null)
        {
            onFail ??= () => new ArgumentException();

            var result = self.IfTrue(FailHandler);
            return result;
            
            void FailHandler()
            {
                var exception = onFail.Invoke();
                throw exception;
            }
        }

        public static SoHandler ThrowIfTrue(this bool self, Func<Exception> onFail = null)
        {
            onFail ??= () => new ArgumentException();

            var result = self.IfTrue(FailHandler);
            return result;
            
            void FailHandler()
            {
                var exception = onFail.Invoke();
                throw exception;
            }
        }

        public static SoHandler ThrowIfFalse(this Func<bool> self, Func<Exception> onFail = null)
        {
            onFail ??= () => new ArgumentException();

            var result = self.IfFalse(FailHandler);
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

            var result = self.IfFalse(FailHandler);
            return result;
            
            void FailHandler()
            {
                var exception = onFail.Invoke();
                throw exception;
            }
        }

        public static SoHandler ThrowIfTrue(this Func<bool> self, Exception exception)
        {
            var result = self.ThrowIfTrue(() => exception);
            return result;
        }

        public static SoHandler ThrowIfTrue(this bool self, Exception exception)
        {
            var result = self.ThrowIfTrue(() => exception);
            return result;
        }

        public static SoHandler ThrowIfFalse(this Func<bool> self, Exception exception)
        {
            var result = self.ThrowIfFalse(() => exception);
            return result;
        }

        public static SoHandler ThrowIfFalse(this bool self, Exception exception)
        {
            var result = self.ThrowIfFalse(() => exception);
            return result;
        }
    }
}