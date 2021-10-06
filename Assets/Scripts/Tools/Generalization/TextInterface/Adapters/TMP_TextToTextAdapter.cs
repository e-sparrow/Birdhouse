using TMPro;

namespace ESparrow.Utils.Tools.Generalization.TextInterface.Adapters
{
    public class TMP_TextToTextAdapter : ToTextAdapterBase
    {
        private readonly TMP_Text _text;

        public TMP_TextToTextAdapter(TMP_Text text)
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
