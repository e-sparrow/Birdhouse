using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums.Mono
{
    [AddComponentMenu("ESparrow/Utils/Tools/Pendulums/MonoPendulum")]
    public class MonoPendulum : MonoBehaviour, IPendulum
    {
        public event Action OnTickPerformed = () => { };

        [SerializeField] private float seconds;

        private float _startTime;

        private void OnEnable()
        {
            _startTime = Time.time;
        }

        private void Update()
        {
            float moduleBefore = (PassedTime - Time.deltaTime) % seconds;
            float moduleAfter = PassedTime % seconds;

            if (moduleBefore > moduleAfter)
            {
                OnTickPerformed.Invoke();
            }
        }
        
        private float PassedTime => Time.time - _startTime;
        
        public TimeSpan Period => TimeSpan.FromSeconds(seconds);
    }
}