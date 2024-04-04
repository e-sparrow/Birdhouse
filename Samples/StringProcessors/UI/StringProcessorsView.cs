using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Aggregators.Routine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Birdhouse.Samples.StringProcessors
{
    public class StringProcessorsView
        : MonoBehaviour
    {
        [Header("Data")] 
        [SerializeField] private string textToProcess;
        
        [Header("References")]
        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button button;

        private IDisposable _buttonToken;
        
        private void ApplyChanges()
        {
            // TODO:
        }
        
        private void OnEnable()
        {
            _buttonToken = button.AddDisposableListener(ApplyChanges);
        }

        private void OnDisable()
        {
            _buttonToken.Dispose();
        }
    }
}