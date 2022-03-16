using System;

namespace ESparrow.Utils.Generic.States.Interfaces
{
    public interface IState<T>
    {
        /// <summary>
        /// Event calling when value of the state is changed
        /// </summary>
        event Action<T> OnValueChanged;
    
        /// <summary>
        /// Gets previous state (likewise command "undo") of this variable.
        /// </summary>
        /// <returns>Previous state</returns>
        IState<T> Back();
        /// <summary>
        /// Gets next state (likewise command "redo") of this variable.
        /// </summary>
        /// <returns>Next state</returns>
        IState<T> Forward();
        
        /// <summary>
        /// Sets the value of this variable.
        /// </summary>
        /// <param name="value">Value to apply</param>
        /// <returns>This variable with new value</returns>
        IState<T> Set(T value);

        /// <summary>
        /// Creates info about this state to restore it later.
        /// </summary>
        /// <returns>Info about this state</returns>
        IStateInfo<T> CreateStateInfo();
        
        /// <summary>
        /// Current value of this variable
        /// </summary>
        T Value
        {
            get;
        }

        /// <summary>
        /// Is undo stack is not empty.
        /// </summary>
        bool CanGetBack
        {
            get;
        }

        /// <summary>
        /// Is redo stack is not empty.
        /// </summary>
        bool CanGetForward
        {
            get;
        }
    }
}
