using UnityEngine;
using TMPro;

namespace Demos.Patterns.CommandPattern
{
    public class MathCommandBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private MathCommand _mathCommand;

        public void Init(MathCommand mathCommand)
        {
            _mathCommand = mathCommand;

            var message = _mathCommand.Message;
            text.text = message;
            text.color = message == "+" ? Color.green : Color.red;
        }
    }
}
