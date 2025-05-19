using System;
using Birdhouse.Tools.Strings.Abstractions;

namespace Birdhouse.Tools.Strings
{
    public static class TagProcessorHelper
    {
        static TagProcessorHelper()
        {
            StorageToken = TagProcessorStorage.RegisterProcessor(DefaultKey, DefaultProcessor);
        }

        private const string DefaultKey = "default";
        
        private static readonly Lazy<ITagProcessor> LazyDefaultProcessor = new Lazy<ITagProcessor>(CreateProcessor);
        
        // TODO: Dispose it.
        private static readonly IDisposable StorageToken;
        
        public static ITagProcessor DefaultProcessor => LazyDefaultProcessor.Value;

        public static void ForceRegisterProcessor()
        {
            // TODO: Find some more elegant solution
        }
        
        private static ITagProcessor CreateProcessor()
        {
            var result = new TagProcessor();
            return result;
        }
    }
}