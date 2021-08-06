using ESparrow.Utils.Tools.Errors.Interfaces;

namespace ESparrow.Utils.Tools.Errors.Adapters
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

        public ToErroneousAdapterBase(T value)
        {
            Value = value;
        }

        public abstract bool CompareWithError(T self, T other, T error);

        public bool CompareWithError(T other, T error)
        {
            return CompareWithError(Value, other, error);
        }

        public bool Compare(T self, T other)
        {
            return CompareWithError(self, other, DefaultError);
        }
    }
}
