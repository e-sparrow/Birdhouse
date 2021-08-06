namespace ESparrow.Utils.Tools.Errors.Interfaces
{
    public interface IErroneous<T>
    {
        public T Value
        {
            get;
            set;
        }

        public T DefaultError 
        { 
            get; 
        }

        public bool CompareWithError(T other, T error);
        public bool CompareWithError(T self, T other, T error);
    }
}
