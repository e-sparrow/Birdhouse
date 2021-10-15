namespace ESparrow.Utils.Generalization.Errors.Interfaces
{
    public interface IErroneous<T>
    { 
        /// <summary>
        /// Compares erroneous inheritors with specified error.
        /// </summary>
        /// <param name="other">Another inheritor</param>
        /// <param name="error">Specified error value</param>
        /// <returns>True if compare is successful and false otherwise</returns>
        bool CompareWithError(T other, T error);
        
        /// <summary>
        /// Current value of erroneous inheritor.
        /// </summary>
        T Value
        {
            get;
            set;
        }

        /// <summary>
        /// Default error of type of erroneous inheritor.
        /// </summary>
        T DefaultError 
        { 
            get; 
        }
    }
}
