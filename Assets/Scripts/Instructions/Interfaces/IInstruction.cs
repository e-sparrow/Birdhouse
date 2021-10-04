using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Instructions.Interfaces
{
    public interface IInstruction
    {
        Action OnDestroy
        {
            get;
        }

        bool SelfDestroy
        {
            get;
        }

        Task Wait(CancellationToken token);

        bool TryExecute();
    }
}
