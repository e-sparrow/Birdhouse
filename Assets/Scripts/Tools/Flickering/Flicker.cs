using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using ESparrow.Utils.Assertions;
using Random = UnityEngine.Random;

namespace ESparrow.Utils.Tools.Flickering
{
    public class Flicker : MonoBehaviour
    {
        [SerializeField] private string code;
        [SerializeField] private float step;

        [SerializeField] private List<CharUnityEventPair> serializedPairs;

        protected virtual List<CharActionPair> DefaultPairs => new List<CharActionPair>();

        protected List<CharActionPair> AllPairs => GetAllPairs();

        // Инициируется на старте для рассинхронизации мерцания. То есть, если попадутся два искрящихся фонарика, то мерцать они будут асинхронно. 
        private float _offset; 

        private List<CharActionPair> GetAllPairs()
        {
            var serializedActionPairs = serializedPairs.Select(value => new CharActionPair(value));
            var allPairs = serializedActionPairs.Concat(DefaultPairs).ToList();

            return allPairs;
        }

        private Action GetActionByChar(char character)
        {
            return AllPairs.FirstOrDefault(value => value.character == character).action;
        }

        private void Start()
        {
            _offset = Random.Range(0, step);
        }

        private void Update()
        {
            AssertionProvider.IsDefaultOrEmpty(code, gameObject).AsException().Assert();

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
        }
    }
}
