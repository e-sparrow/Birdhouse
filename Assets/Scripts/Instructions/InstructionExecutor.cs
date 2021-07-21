using System.Collections.Generic;
using ESparrow.Utils.Instructions.Kinds;

namespace ESparrow.Utils.Instructions
{
    public class InstructionExecutor
    {
        // Проеряются каждый вызов Check.
        private readonly List<InstructionBase> _instructions = new List<InstructionBase>();

        // Последняя инструкция каждой очереди проверяются каждый кадр. Когда она выполняется, переходит к следующей.
        private readonly List<InstructionsQueue> _instructionsQueues = new List<InstructionsQueue>();

        public void Check()
        {
            CheckInstructions();
            CheckQueues();

            void CheckInstructions()
            {
                var incomingEveryFrame = new List<InstructionBase>(_instructions);
                foreach (var instruction in incomingEveryFrame)
                {
                    bool executed = instruction.TryExecute();

                    if (executed && instruction.SelfDestroy)
                    {
                        instruction.OnDestroy.Invoke();
                        _instructions.Remove(instruction);
                    }
                }
            }

            void CheckQueues()
            {
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
            _instructions.Add(instruction);
        }

        public void RemoveInstruction(InstructionBase instruction)
        {
            instruction.OnDestroy?.Invoke();
            _instructions.Remove(instruction);
        }
    }
}
