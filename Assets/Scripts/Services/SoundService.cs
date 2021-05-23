using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Collections.Generic;
using ESparrow.Utils.Instances;

namespace ESparrow.Utils.Services
{
    [AddComponentMenu("ESparrow/Utils/Services/SoundService")]
    public class SoundService : MonoBehaviour
    {
        [SerializeField] private GameObject sourcePrefab;

        // Здесь хранятся кривые с определёнными настройками звука.
        [SerializeField] private EnumValueCollection<ESoundVolumeType, AnimationCurve> curveVolumeTypePairs;

        // Список из пар имя-звук, заполняемый в инспекторе.
        [SerializeField] private List<NameAudioClipPair> nameAudioClipPairs;

        // Список уничтожаемых звуков.
        private readonly List<DestroyableAudioSource> _sources = new List<DestroyableAudioSource>();

        /// <summary>
        /// Включает звук до вызова метода Stop() с тем же аргументом.
        /// </summary>
        public void PlayToStop(string name)
        {
            if (_sources.Any(value => value.Name == name))
            {
                return;
            }
            else
            {
                CreateSource(ESoundVolumeType.Default).InitToStop(name, GetAudioClipByName(name));
            }
        }

        /// <summary>
        /// Останавливает воспроизведение звука с указанным именем, если он работает.
        /// В обратном случае выводит ошибку.
        /// </summary>
        public void Stop(string name)
        {
            if (_sources.Any(value => value.Name == name))
            {
                _sources.FirstOrDefault(value => value.Name == name).Stop();
            }
            else
            {
                Debug.LogWarning($"There is no some sources called '{name}' in SoundService.");
            }
        }

        /// <summary>
        /// Проигрывает звук по его имени в списке определённое время.
        /// </summary>
        public void PlayFor
        (
            string name, 
            float duration, 
            ESoundVolumeType type = ESoundVolumeType.Default
        )
        {
            if (_sources.Any(value => value.Name == name))
            {
                _sources.FirstOrDefault(value => value.Name == name).AddTime(duration);
            }
            else
            {
                var source = Instantiate(sourcePrefab, transform);
                var component = source.GetComponent<DestroyableAudioSource>();

                CreateSource(type).Init(name, GetAudioClipByName(name), duration);
            }
        }

        /// <summary>
        /// Проигрывает звук по его имени в списке один раз.
        /// </summary>
        public void PlayOneShot(string name, ESoundVolumeType type = ESoundVolumeType.Default)
        {
            CreateSource(type).Init(name, GetAudioClipByName(name));
        }

        /// <summary>
        /// Создаёт, добавляет в список и возвращает кастомный компонент звука.
        /// </summary>
        private DestroyableAudioSource CreateSource(ESoundVolumeType type)
        {
            var source = Instantiate(sourcePrefab, transform);
            var component = source.GetComponent<DestroyableAudioSource>();

            component.VolumeCurve = GetCurveByType(type);
            component.onSoundEnded += OnSoundEnded;
            _sources.Add(component);

            return component;

            void OnSoundEnded()
            {
                component.onSoundEnded -= OnSoundEnded;
                _sources.Remove(component);
            }
        }

        /// <summary>
        /// Получает префаб из списка и возвращает его, либо выдаёт ошибку, если его не найдёт.
        /// </summary>
        private AnimationCurve GetCurveByType(ESoundVolumeType type)
        {
            if (curveVolumeTypePairs[type] != null)
            {
                return curveVolumeTypePairs[type];
            }
            else
            {
                throw new Exception($"No prefab with type {type} in list.");
            }
        }

        /// <summary>
        /// Получает звук по его имени в списке.
        /// </summary>
        private AudioClip GetAudioClipByName(string name)
        {
            if (nameAudioClipPairs.Any(value => value.name == name))
            {
                return nameAudioClipPairs.FirstOrDefault(value => value.name == name).clip;
            }
            else
            {
                throw new Exception($"Naming error in SoundService! Service doesn't got pair with name {name}.");
            }
        }

        /// <summary>
        /// Сериализуемая пара имя-звук. 
        /// </summary>
        [Serializable]
        private struct NameAudioClipPair
        {
            public string name;
            public AudioClip clip;
        }
    }
}
