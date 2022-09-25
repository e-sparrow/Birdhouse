using System;
using UnityEngine;

namespace Birdhouse.Common.Instances.Interfaces
{
    public interface IDestroyableAudioSource
    {
        event Action OnSoundEnded;

        AnimationCurve VolumeCurve
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        void Init(string name, AudioClip clip);
        void Init(string name, AudioClip clip, float duration);

        void InitToStop(string name, AudioClip clip);

        void Stop();

        void AddTime(float duration);
    }
}
