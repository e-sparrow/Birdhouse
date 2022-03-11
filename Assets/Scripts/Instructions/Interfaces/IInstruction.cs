using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Instructions.Interfaces
{
    public interface IInstruction
    {
        bool TryExecute();
        void Destroy();
    }
}
