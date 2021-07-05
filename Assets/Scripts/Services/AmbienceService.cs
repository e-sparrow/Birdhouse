using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Collections.Generic;

namespace ESparrow.Utils.Services
{
    [AddComponentMenu("Utils/Services/AmbientService")]
    public class AmbienceService : MonoBehaviour
    {
        [SerializeField] private float defaultTransitionDuration;

        [SerializeField] private GameObject audioSourcePrefab;

        [SerializeField] private AudioClip defaultClip;

        [SerializeField] private KeyValueCollection<string, AudioClip> clips;

        private float _currentVolume = 1f;

        private AudioSource _currentSource;

        public void SetVolume(float volume, float duration = 0f)
        {
            float tempVolume = _currentVolume;
            _currentVolume = volume;

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                _currentSource.volume = Mathf.Lerp(tempVolume, _currentVolume, progress);
            }
        }

        public void SetVolume(float volume)
        {
            _currentSource.volume = volume;
            _currentVolume = volume;
        }

        public void SetClip(AudioClip clip, float duration = 0f)
        {
            if (_currentSource != null)
            {
                if (clip == _currentSource.clip)
                {
                    return;
                }
            }

            var newSource = Instantiate(audioSourcePrefab, transform);
            var component = newSource.GetComponent<AudioSource>();

            component.clip = clip;
            component.Play();

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.CoroutineWithCallback(CoroutinesHelper.Graduate(SetProgress, duration, false, null), DestroyPrevious));

            void SetProgress(float progress)
            {
                float volume = Mathf.Lerp(0f, _currentVolume, progress);

                if (_currentSource != null)
                {
                    _currentSource.volume = _currentVolume - volume;
                }

                component.volume = volume;
            }

            void DestroyPrevious()
            {
                if (_currentSource != null)
                {
                    Destroy(_currentSource.gameObject);
                }

                _currentSource = component;
            }
        }

        public void SetClip(string name)
        {
            SetClip(GetAmbienceByName(name), defaultTransitionDuration);
        }

        public void Play()
        {
            _currentSource.Play();
        }

        public void Pause()
        {
            _currentSource.Pause();
        }

        public AudioClip GetAmbienceByName(string name)
        {
            return clips[name];
        }

        private void Start()
        {
            if (defaultClip != null)
            {
                SetClip(defaultClip);
            }
        }
    }
}
