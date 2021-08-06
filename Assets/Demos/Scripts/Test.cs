using UnityEngine;
using ESparrow.Utils.Assertions;
using ESparrow.Utils.Extensions;

namespace Demos
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            var color = Color.green.SetAlpha(0.5f);

            var toHex = color.ToHexadecimal();
            var fromHex = toHex.FromHexadecimal().ToHexadecimal().FromHexadecimal();

            AssertionProvider.IsEquals(color, fromHex, gameObject).AsMessage().WithColor(Color.red).WithCallback(Assert).Assert();

            void Assert()
            {
                Debug.Log(color);
                Debug.Log(fromHex);
            }
        }
    }
}
