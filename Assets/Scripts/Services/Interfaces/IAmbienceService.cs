using UnityEngine;

namespace ESparrow.Utils.Services.Interfaces
{
    public interface IAmbienceService
    {
        void SetVolume(float volume, float duration);
        void SetVolume(float volume);

        void SetClip(AudioClip clip, float duration);
        void SetClip(string name);

        void Play();
        void Pause();
    }
}
