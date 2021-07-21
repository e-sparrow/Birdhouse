using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Asyncs
{
    public class ImprovedCancellationTokenSource : CancellationTokenSource
    {
        public event Action OnCancellationRequested = () => { };

        public ImprovedCancellationTokenSource() : base()
        {
            Init();
        }

        public ImprovedCancellationTokenSource(int millisecondsDelay) : base(millisecondsDelay)
        {
            Init();
        }

        public ImprovedCancellationTokenSource(TimeSpan delay) : base(delay)
        {
            Init();
        }

        private void Init()
        {
            Token.Register(() => OnCancellationRequested.Invoke());
        }

        public async Task WaitForCancellation()
        {
            await AsyncHelper.WaitUntil(() => true, Token);
        }
    }
}
