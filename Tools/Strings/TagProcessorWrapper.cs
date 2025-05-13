using System;
using Birdhouse.Tools.Strings.Unity;
using TMPro;
using UnityEngine;

namespace Birdhouse.Tools.Strings
{
    public sealed class TagProcessorWrapper
        : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private string processorId;

        private IDisposable _token;

        private void OnEnable()
        {
            var hasProcessor = TagProcessorStorage.TryGetProcessor(processorId, out var processor);
            if (hasProcessor)
            {
                _token = text.WrapWith(processor);
            }
        }

        private void OnDisable()
        {
            _token?.Dispose();
        }
    }
}