using System;
using Birdhouse.Tools.Updatables.Abstractions;
using UnityEngine;

namespace Birdhouse.Tools.Updatables.Samples
{
    public sealed class UpdatableValueSample
        : MonoBehaviour
    {
        private IReadOnlyUpdatableValue<string> _value;
        private IDisposable _token;

        private static void HandleUpdate(string value)
        {
            Debug.Log(value);
        }
        
        private void OnEnable()
        {
            _value = new UpdatableValueBuilder<string>(() => "aboba")
                .WithWriter(out var writer)
                // .AsLazy()
                .BuildReadOnly();
            
            _token = writer
                .WrapIncremental()
                .IncrementWithPeriod(1.0f)
                .Start(index => $"index: {index}");

            _value.OnUpdate += HandleUpdate;
        }

        private void OnDisable()
        {
            _token.Dispose();
            _value.OnUpdate -= HandleUpdate;
        }
    }
}