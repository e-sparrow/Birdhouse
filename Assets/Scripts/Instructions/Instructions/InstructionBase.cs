using System;

namespace ESparrow.Utils.Instructions.Kinds
{
    public abstract class InstructionBase
    {
        protected virtual Action Action
        {
            get;
        }

        protected abstract Func<bool> Condition
        {
            get;
        }

        protected Action OnDestroy
        {
            get;
        }

        public bool SelfDestroy
        {
            get;
        } = false;

        public InstructionBase(Action action, bool selfDestroy = false, Action onDestroy = default)
        {
            Action = action;
            SelfDestroy = selfDestroy;
            OnDestroy = onDestroy;
        }

        public virtual bool TryExecute()
        {
            if (Condition.Invoke())
            {
                Action.Invoke();
                return true;
            }

            return false;
        }
    }
}
