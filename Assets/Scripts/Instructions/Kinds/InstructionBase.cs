using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Instructions.Interfaces;

namespace ESparrow.Utils.Instructions.Kinds
{
    public abstract class InstructionBase : IInstruction
    {
        protected InstructionBase(Action action, Action onDestroy = default)
        {
            _action = action;
            
            onDestroy ??= () => { };
            _onDestroy = onDestroy;
        }

        private readonly Action _action;
        private readonly Action _onDestroy;

        protected abstract bool Check();

        public bool TryExecute()
        {
            if (Check())
            {
                _action.Invoke();
                return true;
            }

            return false;
        }

        public void Destroy()
        {
            _onDestroy.Invoke();
        }
    }
}
