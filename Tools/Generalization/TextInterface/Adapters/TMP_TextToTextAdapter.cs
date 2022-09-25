using TMPro;

namespace Birdhouse.Tools.Generalization.TextInterface.Adapters
{
    public class TMPTextToTextAdapter : ToTextAdapterBase
    {
        private readonly TMP_Text _text;

        public TMPTextToTextAdapter(TMP_Text text)
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
