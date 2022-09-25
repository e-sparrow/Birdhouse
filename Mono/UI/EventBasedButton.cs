using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using UnityEngine.UI;

namespace Birdhouse.Mono.UI
{
    public class EventBasedButton : Button
    {
        public event Action OnButtonClicked
        {
            add => onClick.AddListener(value.ToUnityAction());
            remove => onClick.RemoveListener(value.ToUnityAction());
        }

        public async Task AwaitClick()
        {
            var source = new CancellationTokenSource();
            OnButtonClicked += source.Cancel;
            
            await AsyncHelper.WaitWhile(() => true, source.Token);
        }
    }
}
