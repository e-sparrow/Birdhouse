using System;
using System.Collections.Generic;
using Birdhouse.Features.Aggregators.Interfaces;
using Birdhouse.Features.Aggregators.Routine.Strings.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Aggregators.Routine.Strings
{
    public class StringTagAggregator
        : IRegistry<ITagModel>, IReadOnlyAggregator<string>
    {
        public StringTagAggregator(ITagPatternModel pattern)
        {
            _pattern = pattern;
        }
        
        private readonly ITagPatternModel _pattern;
        
        private readonly IRegistryEnumerable<ITagModel> _tags 
            = new RegistryEnumerable<ITagModel>();
        
        public IDisposable Register(ITagModel element)
        {
            var result = _tags.Register(element);
            return result;
        }
        
        public string Process(string source)
        {
            // TODO:
            // Сначала локализуем строку "Name" из глобальных переменных, затем, если глобальная переменная "Localization"
            // (гипотетически - ключ локализации) равен "ru", что означает, что проект работает на русском языке и поддерживает
            // склонение по падежам на русском языке
            
            // <[/Localization == "ru"]?ruCase=Dative><localize>[/Name]</localize></ruCase>
            
            
            // Попробуем сделать то же самое, но при помощи alias, чтобы упростить конструкцию: 
            
            // <command>
            // alias [/Localization == "ru"]?ruCase case
            // </command>
            // <case=Dative><localize>[/Name]</localize></case>
            
            // Алгоритм: 
            // Найти открывающую скобку первого тега
            // Найти вложенные теги таким же образом
            // Если вложенных тегов нет, создать ноду и добавить её к списку

            throw new NotImplementedException();
            
            var nodes = new List<Node>();
            
            for (var index = 0; index < source.Length; index++)
            {
                var character = source[index];

                var startOpenBracket = _pattern.StartsWith.StartsWith;
                for (var startIndex = 0; startIndex < startOpenBracket.Length; startIndex++)
                {
                    if (character != startOpenBracket[index])
                    {
                        continue;
                    }
                    
                    index++;
                }
            }
        }

        public void Dispose()
        {
            _tags.Dispose();
        }

        private readonly struct Node
        {
            public Node(int index, int length, int depth)
            {
                Index = index;
                Length = length;
                Depth = depth;
            }

            public int Index
            {
                get;
            }

            public int Length
            {
                get;
            }
            
            public int Depth
            {
                get;
            }
        }
    }
}