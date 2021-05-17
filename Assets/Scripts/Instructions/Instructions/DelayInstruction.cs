using System;
using UnityEngine;

namespace ESparrow.Utils.Instructions.Kinds
{
    /// <summary>
    /// Тип инструкций, выполняемый через определённый промежуток времени, указанный первым аргументом в инструкции.
    /// Если selfDestroy равен true, то выполняется всего один раз. В обратном случае, выполняется с той же периодичностью до тех пор, пока его не удалят из Executor'а.
    /// </summary>
    public class DelayInstruction : InstructionBase
    {
        protected override Func<bool> Condition => () => _currentProgress >= _delay;

        private float _currentProgress;
        private readonly float _delay;

        public DelayInstruction
        (
            float delay, 
            Action action, 
            bool selfDestroy = false, 
            Action onDestroy = default
        ) : base(action, selfDestroy, onDestroy)
        {
            _currentProgress = 0f;
            _delay = delay;
        }

        public override bool TryExecute()
        {
            bool result = base.TryExecute();

            if (result)
            {
                _currentProgress = 0f;
            }
            else
            {
                _currentProgress += Time.deltaTime;
            }

            return result;
        }
    }
}
