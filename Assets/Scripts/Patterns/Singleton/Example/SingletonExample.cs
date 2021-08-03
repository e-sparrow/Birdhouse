using UnityEngine;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Patterns.Singleton.Examples
{
    public class SingletonExample : UnitySingleton<SingletonExample>
    {
        private void Start()    
        {
            Debug.Log($"Is my singleton working correct? {(Instance == this ? "Yes, of course".WithColor(Color.green) : "Oops. No".WithColor(Color.red)).Bold()}");
            Debug.Log($"How many SingletonExamples is in the scene? Just {FindObjectsOfType<SingletonExample>().Length.ToString().WithColor(Color.cyan).Bold()}");
        }
    }
}
