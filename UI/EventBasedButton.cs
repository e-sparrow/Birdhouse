using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;
using ESparrow.Utils.Asynchronous;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.UI
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
