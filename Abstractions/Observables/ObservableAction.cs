using System;

namespace Birdhouse.Abstractions.Observables
{
    public class ObservableAction 
        : ObservableActionBase
    {
        public ObservableAction(Action action = null)
        {
            action ??= () => { };
            _action = action;
        }

        private readonly Action _action;
        
        protected override void InvokeInternal()
        {
            _action.Invoke();   
        }
    }
}