using System;

namespace ESparrow.Utils.Tools.Eases.Interfaces
{
    public interface IFluentEase : IEase
    {
        /// <summary>
        /// Inverses ease by X.
        /// </summary>
        /// <returns>Inversed ease</returns>
        IFluentEase InverseX();
        /// <summary>
        /// Inverses ease by Y.
        /// </summary>
        /// <returns>Inversed ease</returns>
        IFluentEase InverseY();

        /// <summary>
        /// Increases ease by specified value.
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>Increased ease</returns>
        IFluentEase IncreaseBy(float value);
        /// <summary>
        /// Decreases ease by specified value.
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>Decreased ease</returns>
        IFluentEase DecreaseBy(float value);

        /// <summary>
        /// Multiplies ease by specified value.
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>Multiplied ease</returns>
        IFluentEase MultipleBy(float value);
        /// <summary>
        /// Divides ease by specified value.
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>Divided ease</returns>
        IFluentEase DivideBy(float value);

        /// <summary>
        /// Raise ease to specified power.
        /// </summary>
        /// <param name="value">Specified power</param>
        /// <returns>Raised ease</returns>
        IFluentEase Pow(float value);

        /// <summary>
        /// Modifies ease by specified functions.
        /// </summary>
        /// <param name="func">Function of second ease</param>
        /// <param name="operation">Operation between two floats to interact functions</param>
        /// <returns>Modified ease</returns>
        IFluentEase Modify(Func<float, float> func, Func<float, float, float> operation);
    }
}
