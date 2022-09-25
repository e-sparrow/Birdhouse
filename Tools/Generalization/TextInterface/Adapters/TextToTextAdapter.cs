using UnityEngine.UI;

namespace Birdhouse.Tools.Generalization.TextInterface.Adapters
{
    public class TextToTextAdapter : ToTextAdapterBase
    {
        private readonly Text _text;

        public TextToTextAdapter(Text text)
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
