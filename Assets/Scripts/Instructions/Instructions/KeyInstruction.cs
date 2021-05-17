using System;
using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Instructions.Kinds
{
    /// <summary>
    /// Тип инструкций, вызываемый по нажатию/отжатию/удержанию какой-либо из клавиш.
    /// </summary>
    public class KeyInstruction : InstructionBase
    {
        protected override Func<bool> Condition => () => _keyCode.IsKeyAtState(_targetState);

        private readonly KeyCode _keyCode;
        private readonly EKeyState _targetState;

        public KeyInstruction
        (
            KeyCode keyCode, 
            EKeyState targetState, 
            Action action, 
            bool selfDestroy = false, 
            Action onDestroy = default
        ) : base(action, selfDestroy, onDestroy)
        {
            _keyCode = keyCode;
            _targetState = targetState;
        }
    }
}
