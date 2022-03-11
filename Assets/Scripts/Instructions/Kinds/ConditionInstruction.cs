using System;

namespace ESparrow.Utils.Instructions.Kinds
{
    public class ConditionInstruction : InstructionBase
    {
        public ConditionInstruction
        (
            Func<bool> condition, 
            Action action, 
            Action onDestroy = default
        ) : base(action, onDestroy)
        {
            _condition = condition;
        }

        private readonly Func<bool> _condition;
        
        protected override bool Check()
        {
            return _condition.Invoke();
        }
    }
}
