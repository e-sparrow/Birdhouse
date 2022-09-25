using System;
using Birdhouse.Tools.Graduating.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Birdhouse.Tools.Graduating
{
    [Serializable]
    public class SerializableGradualSettings : SerializableTweeningSettings, IGradualSettings
    {
        [SerializeField] private UnityEvent<float> action;

        public Action<float> Action => action.Invoke;
    }
}
