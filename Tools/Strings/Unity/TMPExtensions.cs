using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Tools.Strings.Abstractions;
using TMPro;

namespace Birdhouse.Tools.Strings.Unity
{
    public static class TMPExtensions
    {
        public static IDisposable WrapWith(this TMP_Text self, IReadOnlyTagProcessor processor)
        {
            var tempProcessor = self.textPreprocessor;
            var token = new CallbackDisposable(() => self.textPreprocessor = tempProcessor);
            
            self.textPreprocessor = new TagTextPreprocessor(self.textPreprocessor, processor);
            return token;
        }
    }
}