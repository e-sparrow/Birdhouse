using Birdhouse.Tools.Generalization.Types.Interfaces;

namespace Birdhouse.Tools.Generalization.Summation.Interfaces
{
    public interface ISummable<T> : IGeneralizationAdapter
    {
        /// <summary>
        /// Adds this value to another.
        /// </summary>
        /// <param name="other">Another value</param>
        /// <returns>Result of summation</returns>
        ISummable<T> Plus(T other);
        /// <summary>
        /// Removes another value from this.
        /// </summary>
        /// <param name="other">Another value</param>
        /// <returns>Result of reduction</returns>
        ISummable<T> Minus(T other);

        /// <summary>
        /// Current value of summable inheritor.
        /// </summary>
        T Value
        {
            get;
            set;
        }
    }
}
