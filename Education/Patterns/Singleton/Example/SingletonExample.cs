using Birdhouse.Common.Extensions;
using Birdhouse.Education.Patterns.Singleton.Mono;
using UnityEngine;

namespace Birdhouse.Education.Patterns.Singleton.Example
{
    public class SingletonExample : MonoSingleton<SingletonExample>
    {
        private void Start()    
        {
            Debug.Log($"Is my singleton working correct? {(Instance == this ? "Yes, of course".WithColor(Color.green) : "Oops. No".WithColor(Color.red)).Bold()}");
            Debug.Log($"How many SingletonExamples is in the scene? Just {FindObjectsOfType<SingletonExample>().Length.ToString().WithColor(Color.cyan).Bold()}");
        }
    }
}
