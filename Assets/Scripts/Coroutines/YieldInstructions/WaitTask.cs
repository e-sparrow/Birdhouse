using System.Threading.Tasks;
using UnityEngine;

namespace ESparrow.Utils.Coroutines.YieldInstructions
{
    public class WaitTask : CustomYieldInstruction
    {
        public override bool keepWaiting => _isWaiting;

        private bool _isWaiting = true;

        public WaitTask(Task task)
        {
            Wait(task);
        }

        private async void Wait(Task task)
        {
            await task.ContinueWith(_ => _isWaiting = false);
        }
    }
}
