using UnityEngine;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitForQuitInstruction
        : CoroutineInstructionBase
    {
        public WaitForQuitInstruction(bool preventQuit = false)
        {
            _preventQuit = preventQuit;
            Application.wantsToQuit += OnWantsToQuit;
        }

        private readonly bool _preventQuit;
        
        private bool _needsToQuit = false;
        
        public override bool IsFinished(float deltaTime)
        {
            return _needsToQuit;
        }

        private bool OnWantsToQuit()
        {
            Application.wantsToQuit -= OnWantsToQuit;
            
            _needsToQuit = true;
            return !_preventQuit;
        }
    }
}