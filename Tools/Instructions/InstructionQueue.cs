using System.Collections.Generic;
using System.Linq;
using Birdhouse.Tools.Instructions.Interfaces;

namespace Birdhouse.Tools.Instructions
{
    /// <summary>
    /// Queue of instructions which helps execute it one after another.
    /// </summary>
    public class InstructionQueue : InstructionQueueBase
    {
        private IList<IInstruction> _instructions = new List<IInstruction>();

        public InstructionQueue(params IInstruction[] instructions) : this(instructions.AsEnumerable()) 
        { 
           
        }

        public InstructionQueue(IEnumerable<IInstruction> instructions)
        {
            Add(instructions);
        }

        public override bool TryExecuteLast(out bool last)
        {
            last = false;

            if (_instructions.Count == 0) return false;
            
            bool executed = _instructions.Last().TryExecute();
            
            if (!executed) return false;
            
            _instructions.Last().Destroy();
            Skip(1);    
                    
            last = _instructions.Count == 0;

            return false;
        }

        public override void Add(IInstruction instruction)
        {
            _instructions.Add(instruction);
        }

        public override void Skip()
        {
            _instructions.Remove(_instructions.Last());
        }

        public void Add(params IInstruction[] instructions)
        {
            Add(instructions.AsEnumerable());
        }

        public void Add(IEnumerable<IInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                Add(instruction);
            }
        }

        public override void Reverse()
        {
            _instructions = _instructions.Reverse().ToList();
        }

        public void Skip(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Skip();
            }
        }
    }
}
