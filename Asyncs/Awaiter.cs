using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Asyncs
{
    public class Awaiter
    {
        private readonly CancellationToken _token;

        public Awaiter(CancellationToken token)
        {
            _token = token;
        }

        public Awaiter(int milliseconds)
        {
            _token = new ImprovedCancellationTokenSource(milliseconds).Token;
        }

        public Awaiter(ref Action action)
        {
            var source = new ImprovedCancellationTokenSource();
            _token = source.Token;
            
            action += source.Cancel;
        }

        public async Task Await()
        {
            await AsyncHelper.WaitWhile(() => true, _token);
        }
    }
}
