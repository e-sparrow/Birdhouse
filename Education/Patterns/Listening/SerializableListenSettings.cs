using System;
using Birdhouse.Education.Patterns.Listening.Interfaces;
using UnityEngine;

namespace Birdhouse.Education.Patterns.Listening
{
    [Serializable]
    public struct SerializableListenSettings : IListenSettings
    {
        [SerializeField] private double delaySeconds;
        [SerializeField] private int callsCount;

        public TimeSpan Delay => TimeSpan.FromSeconds(delaySeconds);
        public int CallsCount => callsCount;
    }
}
