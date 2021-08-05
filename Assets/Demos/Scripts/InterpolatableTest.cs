using UnityEngine;
using ESparrow.Utils.Tools;
using ESparrow.Utils.Extensions;

public class InterpolatableTest : MonoBehaviour
{
    [SerializeField] private float interpolatableValue = 5f;

    private void Start()
    {
        var reference = new Reference<float>(() => interpolatableValue, value => interpolatableValue = value);
        reference.AsInterpolatable().InterpolateFor(500f, 10f).Start();
    }
}
