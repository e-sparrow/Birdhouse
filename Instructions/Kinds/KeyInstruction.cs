using System;
using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Inputs.Pressures.Enums;

namespace ESparrow.Utils.Instructions.Kinds
{
    public class KeyInstruction : InstructionBase
    {
        public KeyInstruction
        (
            KeyCode keyCode, 
            EPressureState targetState, 
            Action action, 
            Action onDestroy = default
        ) : base(action, onDestroy)
        {
            _keyCode = keyCode;
            _targetState = targetState;
        }
        
        private readonly KeyCode _keyCode;
        private readonly EPressureState _targetState;

        protected override bool Check()
        {
            return _keyCode.IsKeyAtState(_targetState);
        }
    }
}
