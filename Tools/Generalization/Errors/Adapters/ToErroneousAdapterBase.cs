using Birdhouse.Tools.Generalization.Errors.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Errors.Adapters
{
    public abstract class ToErroneousAdapterBase<T> : IErroneous<T>
    {
        public T Value
        {
            get;
            set;
        }

        public abstract T DefaultError
        {
            get;
        }

        /// <summary>
        /// Creates erroneous by specified value.
        /// </summary>
        /// <param name="value">Specified value</param>
        protected ToErroneousAdapterBase(T value)
        {
            Value = value;
        }

        protected abstract bool CompareWithError(T self, T other, T error);

        public bool CompareWithError(T other, T error)
        {
            return CompareWithError(Value, other, error);
        }

        public bool Compare(T self, T other)
        {
            return CompareWithError(self, other, DefaultError);
        }

        public abstract EGeneralizationType GeneralizationType
        {
            get;
        }
    }
}
