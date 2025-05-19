using System;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Strings.Abstractions;

namespace Birdhouse.Tools.Strings
{
    public static class TagProcessorStorage
    {
        static TagProcessorStorage()
        {
            TagProcessorHelper.ForceRegisterProcessor();
        }
        
        public static readonly ITagProcessor DefaultProcessor = new TagProcessor();
        
        private static readonly IRegistryDictionary<string, IReadOnlyTagProcessor> Processors 
            = new RegistryDictionary<string, IReadOnlyTagProcessor>();

        public static IDisposable RegisterProcessor(string id, ITagProcessor processor)
        {
            var result = Processors.Register(id, processor);
            return result;
        }

        public static bool TryGetProcessor(string id, out IReadOnlyTagProcessor processor)
        {
            var result = Processors.TryGetValue(id, out processor);
            return result;
        }
    }
}