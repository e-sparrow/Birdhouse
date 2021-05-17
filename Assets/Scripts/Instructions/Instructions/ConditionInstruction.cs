using System;

namespace ESparrow.Utils.Instructions.Kinds
{
    /// <summary>
    /// Самый примитивный вид инструкций, но так же и самый универсальный, ведь он может "спародировать" все остальные типы инструкций.
    /// Использовать рекомендую только в том случае, если посредством других инструкций Ваша задача не решается. В остальном - в нём надобности мало.
    /// </summary>
    public class ConditionInstruction : InstructionBase
    {
        protected override Func<bool> Condition => _condition;

        private readonly Func<bool> _condition = () => false;

        public ConditionInstruction
        (
            Func<bool> condition, 
            Action action, 
            bool selfDestroy = false, 
            Action onDestroy = default
        ) : base(action, selfDestroy, onDestroy)
        {
            _condition = condition;
        }
    }
}
