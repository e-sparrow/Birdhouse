using Birdhouse.Tools.Strings.Abstractions;
using TMPro;

namespace Birdhouse.Tools.Strings.Unity
{
    public sealed class TagTextPreprocessor
        : ITextPreprocessor
    {
        public TagTextPreprocessor(ITextPreprocessor inner, IReadOnlyTagProcessor processor)
        {
            _inner = inner;
            _processor = processor;
        }

        private readonly ITextPreprocessor _inner;
        private readonly IReadOnlyTagProcessor _processor;
        
        public string PreprocessText(string text)
        {
            var result = _inner.PreprocessText(text);
            result = _processor.Process(result);

            return result;
        }
    }
}