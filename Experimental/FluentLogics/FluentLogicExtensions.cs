using System;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Experimental.FluentLogics
{
    public static class FluentLogicExtensions
    {
        public static BranchingSoHandler IfTrue(this bool self, Action action) => new BranchingRoot(() => self).So(action);
        public static BranchingSoHandler IfTrue(this Func<bool> self, Action action) => new BranchingRoot(self).So(action);
        public static BranchingSoHandler IfFalse(this bool self, Action action) => new BranchingRoot(() => !self).So(action);
        public static BranchingSoHandler IfFalse(this Func<bool> self, Action action) => new BranchingRoot(self.Reverse()).So(action);

        public static BranchingSoHandler ThrowIfTrue(this Func<bool> self, Func<Exception> onFail = null)
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

        public static BranchingSoHandler ThrowIfTrue(this bool self, Func<Exception> onFail = null)
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

        public static BranchingSoHandler ThrowIfFalse(this Func<bool> self, Func<Exception> onFail = null)
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

        public static BranchingSoHandler ThrowIfFalse(this bool self, Func<Exception> onFail = null)
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

        public static BranchingSoHandler ThrowIfTrue(this Func<bool> self, Exception exception) => self.ThrowIfTrue(() => exception);
        public static BranchingSoHandler ThrowIfTrue(this bool self, Exception exception) => self.ThrowIfTrue(() => exception);
        public static BranchingSoHandler ThrowIfFalse(this Func<bool> self, Exception exception) => self.ThrowIfFalse(() => exception);
        public static BranchingSoHandler ThrowIfFalse(this bool self, Exception exception) => self.ThrowIfFalse(() => exception);
    }
}