using UnityEngine;

namespace Birdhouse.Experimental.FluentLogics.Samples
{
    public sealed class FluentSwitchSample
        : MonoBehaviour
    {
        [ContextMenu("Execute sample")]
        private void ExecuteSample()
        {
            1.Switch()
                .Case(1).So(() => Debug.Log($"It's 1!"))
                .Case(2).So(() => Debug.Log($"It's 2!!"))
                .Case(3).So(() => Debug.Log($"It's 3!!!"))
                .Default(() => Debug.Log($"I dunno what is it"));

            var result = 1.Switch<int, string>()
                .Case(1).So("It's 1!")
                .Case(2).So("It's 2!!")
                .Case(3).So("It's 3!!!")
                .Default("I dunno what is it");
            Debug.Log($"Resulting switch result: \"{result}\"");
        }
    }
}