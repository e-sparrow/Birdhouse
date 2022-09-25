using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Birdhouse.Tools.Flickering
{
    public class Flicker : MonoBehaviour
    {
        [SerializeField] private string code;
        [SerializeField] private float step;

        [SerializeField] private List<CharUnityEventPair> serializedPairs;

        [SerializeField] private bool synchronous;

        protected virtual IEnumerable<CharActionPair> Pairs => new List<CharActionPair>();
        protected IEnumerable<CharActionPair> AllPairs => GetAllPairs();

        private float _offset; 

        private List<CharActionPair> GetAllPairs()
        {
            var serializedActionPairs = serializedPairs.Select(value => new CharActionPair(value));
            var allPairs = serializedActionPairs.Concat(Pairs).ToList();

            return allPairs;
        }

        private Action GetActionByChar(char character)
        {
            return AllPairs.FirstOrDefault(value => value.character == character).action;
        }

        private void Start()
        {
            _offset = synchronous ? 0 : Random.Range(0, step);
        }

        private void Update()
        {
            int currentTimeStep = (int) ((_offset + Time.time) / step);
            int currentCharIndex = currentTimeStep % code.Length;

            char currentChar = code[currentCharIndex];

            var currentAction = GetActionByChar(currentChar);

            currentAction.Invoke();
        }

        [Serializable]
        protected struct CharActionPair
        {
            public char character;
            public Action action;

            public CharActionPair(CharUnityEventPair pair)
            {
                character = pair.character;
                action = pair.unityEvent.Invoke;
            }

            public CharActionPair(char character, Action action)
            {
                this.character = character;
                this.action = action;
            }
        }

        [Serializable]
        protected struct CharUnityEventPair
        {
            public char character;
            public UnityEvent unityEvent;

            public CharUnityEventPair(char character, UnityEvent unityEvent)
            {
                this.character = character;
                this.unityEvent = unityEvent;
            }

            public CharUnityEventPair(CharActionPair pair)
            {
                character = pair.character;
                unityEvent = new UnityEvent();
                
                unityEvent.AddListener(pair.action.Invoke);
            }
        }
    }
}
