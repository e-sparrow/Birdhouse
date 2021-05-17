using System.Linq;
using System.Collections.Generic;
using ESparrow.Utils.Instructions.Kinds;

namespace ESparrow.Utils.Instructions
{
    /// <summary>
    /// Класс, представляющий из себя очередь из инструкций, которые Executor выполняет друг за другом. 
    /// Причём, инструкции могут быть разнотипными - допустим, сначала игрок нажимает клавишу, потом через какое-то время выполняется DelayInstruction
    /// </summary>
    public class InstructionsQueue
    {
        private readonly List<InstructionBase> _instructions = new List<InstructionBase>();

        public InstructionsQueue(params InstructionBase[] instructions) : this(instructions.AsEnumerable()) 
        { 
           
        }

        public InstructionsQueue(IEnumerable<InstructionBase> instructions)
        {
            Add(instructions);
        }

        public bool TryExecuteLast(out bool last)
        {
            last = false;

            if (_instructions.Count != 0)
            {
                bool executed = _instructions.Last().TryExecute();
                if (executed)
                {
                    _instructions.Last().OnDestroy.Invoke();
                    Skip();
                    last = _instructions.Count == 0;
                }
            }

            return false;
        }

        public void Add(params InstructionBase[] instructions)
        {
            Add(instructions.AsEnumerable());
        }

        public void Add(IEnumerable<InstructionBase> instructions)
        {
            _instructions.AddRange(instructions);
        }

        public void Reverse()
        {
            _instructions.Reverse();
        }

        public void Skip()
        {
            _instructions.Remove(_instructions.Last());
        }
    }
}
