using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Instructions.Kinds
{
    public abstract class InstructionBase
    {
        protected virtual Action Action
        {
            get;
            private set;
        }

        protected abstract Func<bool> Condition
        {
            get;
        }

        public Action OnDestroy
        {
            get;
            private set;
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

        public async Task Wait(CancellationToken token = new CancellationToken())
        {
            var executed = false;
            Action += () => executed = true;

            await AsyncHelper.WaitUntil(() => executed, token);
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
