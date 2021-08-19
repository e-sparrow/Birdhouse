using UnityEngine;
using ESparrow.Utils.Assertions;
using ESparrow.Utils.Extensions;

namespace Demos
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        [SerializeField] private float number;

        private void Update()
        {
            Debug.Log(number.LoopBetween(min, max));
        }
    }
}
