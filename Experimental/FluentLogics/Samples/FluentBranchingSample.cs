using Birdhouse.Common.Helpers;
using UnityEngine;

namespace Birdhouse.Experimental.FluentLogics.Samples
{
    public sealed class FluentBranchingSample
        : MonoBehaviour
    {
        [ContextMenu("Execute sample")]
        private void ExecuteSample()
        {
            FluentBranching.If(BooleanHelper.Random())
                .So(() => Debug.Log($"It's true"))
                .ElseIf(BooleanHelper.Random)
                .So(() => Debug.Log($"It's false but second random is true"))
                .Else()
                .So(() => Debug.Log($"Everything is false"));
        }
    }
}