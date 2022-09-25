using TMPro;

namespace Birdhouse.Tools.Generalization.TextInterface.Adapters
{
    public class TextMeshProUGUIToTextAdapter : ToTextAdapterBase
    {
        private readonly TextMeshProUGUI _text;

        public TextMeshProUGUIToTextAdapter(TextMeshProUGUI text)
        {
            _text = text;
        }

        public override string Text
        {
            get => _text.text;
            set => _text.text = value;
        }
    }
}