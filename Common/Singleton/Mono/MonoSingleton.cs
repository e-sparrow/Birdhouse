using System;
using System.Linq;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Common.Singleton.Mono
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static readonly Lazy<T> Value = new Lazy<T>(GetOrCreate);

        private static T GetOrCreate()  
        {
            var subjects = FindObjectsOfType<T>();
            if (!subjects.Any())
            {
                var gameObject = new GameObject(typeof(T).Name);
                DontDestroyOnLoad(gameObject);

                var component = gameObject.AddComponent<T>();
                return component;
            }
            else
            {
                var gameObject = subjects.First();
                var component = gameObject.GetComponent<T>();

                if (subjects.Length > 1)
                {
                    var others = subjects.Without(gameObject);
                    foreach (var subject in others)
                    {
                        DestroyImmediate(subject);

                        var message =
                            $"Removed redundant exemplar of {typeof(T).ToString().WithColor(Color.red).Bold()} class";
                        Debug.LogError(message);
                    }
                }

                return component;
            }
        }

        public static T Instance => Value.Value;
        public static bool HasInstance => Value.IsValueCreated;
    }
}