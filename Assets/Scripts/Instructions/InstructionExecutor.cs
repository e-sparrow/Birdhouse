using System.Collections.Generic;
using ESparrow.Utils.Managers;
using ESparrow.Utils.Instructions.Kinds;

namespace ESparrow.Utils.Instructions
{
    public class InstructionExecutor
    {
        // ѕоследн€€ инструкци€ каждой очереди провер€ютс€ каждый кадр.  огда она выполн€етс€, переходит к следующей.
        private readonly List<InstructionsQueue> _instructionsQueues = new List<InstructionsQueue>();
        // Ёти инструкции провер€ютс€ каждый кадр.
        private readonly List<InstructionBase> _everyFrameInstructions = new List<InstructionBase>();

        public InstructionExecutor()
        {
            UnityMessagesManager.Instance.UpdateHandler += OnUpdate;
        }

        ~InstructionExecutor()
        {
            UnityMessagesManager.Instance.UpdateHandler -= OnUpdate;
        }

        public void AddQueue(InstructionsQueue queue)
        { 
            _instructionsQueues.Add(queue);
        }

        public void RemoveQueue(InstructionsQueue queue)
        {
            _instructionsQueues.Remove(queue);
        }

        public void AddInstruction(InstructionBase instruction)
        {
            _everyFrameInstructions.Add(instruction);
        }

        public void RemoveInstruction(InstructionBase instruction)
        {
            instruction.OnDestroy?.Invoke();
            _everyFrameInstructions.Remove(instruction);
        }

        private void OnUpdate()
        {
            var incomingEveryFrame = new List<InstructionBase>(_everyFrameInstructions);
            foreach (var instruction in incomingEveryFrame)
            {
                bool executed = instruction.TryExecute();

                if (executed && instruction.SelfDestroy)
                {
                    instruction.OnDestroy.Invoke();
                    _everyFrameInstructions.Remove(instruction);
                }
            }

            var incomingQueues = new List<InstructionsQueue>(_instructionsQueues);
            foreach (var queue in incomingQueues)
            {
                queue.TryExecuteLast(out bool last);
                if (last)
                {
                    _instructionsQueues.Remove(queue);
                }
            }
        }
    }
}
