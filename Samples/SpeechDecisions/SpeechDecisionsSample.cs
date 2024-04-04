using System;
using Birdhouse.Common.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Birdhouse.Samples.SpeechDecisions
{
    public class SpeechDecisionsSample
        : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private YesNoPopup popup;

        private IDisposable _buttonToken;

        private async void OpenPopup()
        {
            button.enabled = false;
            var decision = await popup.WaitForDecision();
            button.enabled = true;
            
            var decisionText = decision ? "Yes" : "No";
            Debug.Log($"User decided: {decisionText}");
        }
        
        private void OnEnable()
        {
            _buttonToken = button.AddDisposableListener(OpenPopup);
        }

        private void OnDisable()
        {
            _buttonToken.Dispose();
        }
    }
}