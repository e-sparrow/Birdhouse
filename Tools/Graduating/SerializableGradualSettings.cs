using System;
using ESparrow.Utils.Tools.Graduating.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace ESparrow.Utils.Tools.Graduating
{
    [Serializable]
    public class SerializableGradualSettings : SerializableTweeningSettings, IGradualSettings
    {
        [SerializeField] private UnityEvent<float> action;

        public Action<float> Action => action.Invoke;
    }
}
