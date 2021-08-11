using System;
using System.Threading.Tasks;
using UnityEngine.UI;
using ESparrow.Utils.Asyncs;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.UI
{
    public class ImprovedButton : Button
    {
        public event Action OnButtonClicked
        {
            add => onClick.AddListener(value.ToUnityAction());
            remove => onClick.RemoveListener(value.ToUnityAction());
        }

        public async Task AwaitClick()
        {
            var source = new ImprovedCancellationTokenSource();
            OnButtonClicked += source.Cancel;

            await AsyncHelper.WaitUntil(() => source.IsCancellationRequested);
        }
    }
}
