using System;
using System.Threading.Tasks;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Extensions;

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
        public event Action OnSoundEnded = () => { };

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
        private float _durationLeft;

        // Компонент, воспроизводящий звук.
        private AudioSource _source;

        /// <summary>
        /// Инициализация класса для воспроизведения один раз. 
        /// Задаётся нужный звук, воспроизводится и, по окончанию, самоуничтожается.
        /// </summary>
        public void Init(string name, AudioClip clip)
        {
            Name = name;

            _source = GetComponent<AudioSource>();
            _source.clip = clip;

            _durationLeft = clip.length;

            Play();
        }

        /// <summary>
        /// Инициализация класса для воспроизведения определённое время.
        /// Задаётся нужный звук, воспроизводится и самоуничтожается, когда кончается время.
        /// </summary>
        public void Init(string name, AudioClip clip, float duration)
        {
            Name = name;

            _source = GetComponent<AudioSource>();
            _source.clip = clip;
            _source.loop = true;

            _durationLeft = duration;

            Play();
        }

        /// <summary>
        /// Запускает звук до метода остановки.
        /// </summary>
        public void InitToStop(string name, AudioClip clip)
        {
            Name = name;

            _source = GetComponent<AudioSource>();
            _source.clip = clip;
            _source.loop = true;

            _source.Play();
        }

        /// <summary>
        /// Останавливает воспроизведение звука и уничтожает объект.
        /// </summary>
        public void Stop()
        {
            OnSoundEnded.Invoke();

            _source.Stop();
            Destroy(gameObject);
        }

        /// <summary>
        /// Добавляет к таймеру время.
        /// </summary>
        public void AddTime(float duration)
        {
            _durationLeft += duration;
        }

        private async Task Play()
        {
            _source.Play();

            StopAllCoroutines();
            await CoroutinesHelper.Graduate(SetProgress, _durationLeft, false, VolumeCurve).StartAsync();

            Stop();

            void SetProgress(float progress)
            {
                _source.volume = progress;
            }
        }
    }
}
