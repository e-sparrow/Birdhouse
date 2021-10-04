using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Instructions.Interfaces
{
    public interface IInstruction
    {
        public Action OnDestroy
        {
            get;
        }

        public bool SelfDestroy
        {
            get;
        }

        public Task Wait(CancellationToken token);

        public bool TryExecute();
    }
}
