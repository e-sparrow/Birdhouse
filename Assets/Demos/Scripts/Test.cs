using UnityEngine;
using UnityEngine.UI;
using ESparrow.Utils.Asyncs;
using ESparrow.Utils.Helpers;

namespace Demos
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private bool booool;

        private async void Start()
        {
            var source = new ImprovedCancellationTokenSource();
            source.OnCancellationRequested += () => Debug.Log("Cancelled");
            var token = source.Token;

            button.onClick.AddListener(() => source.Cancel());

            await AsyncHelper.WaitWhile(() => booool, token);
            
            Debug.Log($"Ended");
        }
    }
}
