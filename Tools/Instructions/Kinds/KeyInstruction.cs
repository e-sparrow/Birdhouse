using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Instructions.Kinds
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
