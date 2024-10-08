﻿using System;

namespace Birdhouse.Abstractions.Observables
{
    public abstract class ObservableActionBase 
        : IObservableAction
    {
        public event Action OnInvoke = () => { };

        protected abstract void InvokeInternal();
        
        public void Invoke()
        {
            InvokeInternal();
            OnInvoke.Invoke();
        }
    }
}