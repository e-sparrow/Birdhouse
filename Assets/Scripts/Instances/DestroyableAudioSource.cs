using System;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Instances
{
    /// <summary>
    /// Этот класс при инициализации экземпляра запускает звук, указанный в аргументе главного метода.
    /// Когда звук кончается, экземпляр класса и его объект уничтожаются.
    /// </summary>
    [AddComponentMenu("ESparrow/Utils/DestroyableAudioSource")]
    [RequireComponent(typeof(AudioSource))]
    public class DestroyableAudioSource : MonoBehaviour
    {
        // Кривая Безье для нелинейного уменьшения (или увеличения) звука.
        public AnimationCurve VolumeCurve
        {
            get;
            set;
        }

        // Имя звука, задаваемое сервисом звуков, который и будет к нему обращаться, находя в списке.
        public string Name
        {
            get;
            set;
        }

        // Оставшееся время проигрывания.
        private float durationLeft;

        // Компонент, воспроизводящий звук.
        private AudioSource source;

        public Action onSoundEnded = () => { };

        /// <summary>
        /// Инициализация класса для воспроизведения один раз. 
        /// Задаётся нужный звук, воспроизводится и, по окончанию, самоуничтожается.
        /// </summary>
        public void Init(string name, AudioClip clip)
        {
            Name = name;

            source = GetComponent<AudioSource>();
            source.clip = clip;

            durationLeft = clip.length;

            Play();
        }

        /// <summary>
        /// Инициализация класса для воспроизведения определённое время.
        /// Задаётся нужный звук, воспроизводится и самоуничтожается, когда кончается время.
        /// </summary>
        public void Init(string name, AudioClip clip, float duration)
        {
            Name = name;

            source = GetComponent<AudioSource>();
            source.clip = clip;
            source.loop = true;

            durationLeft = duration;

            Play();
        }

        /// <summary>
        /// Запускает звук до метода остановки.
        /// </summary>
        public void InitToStop(string name, AudioClip clip)
        {
            Name = name;

            source = GetComponent<AudioSource>();
            source.clip = clip;
            source.loop = true;

            source.Play();
        }

        /// <summary>
        /// Останавливает воспроизведение звука и уничтожает объект.
        /// </summary>
        public void Stop()
        {
            onSoundEnded.Invoke();

            source.Stop();
            Destroy(gameObject);
        }

        /// <summary>
        /// Добавляет к таймеру время.
        /// </summary>
        public void AddTime(float duration)
        {
            durationLeft += duration;
        }

        private void Play()
        {
            source.Play();

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.CoroutineWithCallback(CoroutinesHelper.Graduate(SetVolume, durationLeft, false, VolumeCurve), Stop));

            void SetVolume(float progress)
            {
                source.volume = progress;
            }
        }
    }
}
