using System;
using Birdhouse.Tools.Strings.Abstractions;

namespace Birdhouse.Tools.Strings
{
    public static class TagProcessorHelper
    {
        private static readonly Lazy<ITagProcessor> LazyDefaultProcessor = new Lazy<ITagProcessor>(CreateProcessor);

        public static ITagProcessor DefaultProcessor => LazyDefaultProcessor.Value;

        private static ITagProcessor CreateProcessor()
        {
            var result = new TagProcessor();
            return result;
        }
    }
}