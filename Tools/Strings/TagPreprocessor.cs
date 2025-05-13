using System;
using System.Collections.Generic;
using System.Text;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Strings.Abstractions;
using UnityEngine;

namespace Birdhouse.Tools.Strings
{
    public sealed class TagPreprocessor
        : ITagPreprocessor
    {
        private readonly IRegistryDictionary<string, ITag> _tags = new RegistryDictionary<string, ITag>();

        public IDisposable RegisterTag(string name, ITag tag)
        {
            var result = _tags.Register(name, tag);
            return result;
        }

        public string Process(string input)
        {
            var builder = new StringBuilder(input);
            var index = 0;

            var result = string.Empty;

            while (index < builder.Length)
            {
                var currentContent = builder.ToString();

                var startTagIndex = currentContent.IndexOf('<', index);
                if (startTagIndex == -1)
                {
                    result += currentContent.Substring(index);
                    break;
                }

                var endTagIndex = currentContent.IndexOf('>', startTagIndex);
                if (endTagIndex == -1)
                {
                    result += currentContent.Substring(index);
                    break;
                }

                result += currentContent.Substring(index, startTagIndex - index);

                var fullTag = currentContent.Substring(startTagIndex + 1, endTagIndex - startTagIndex - 1);

                var isSelfClosingTag = fullTag.EndsWith("/");
                if (isSelfClosingTag) fullTag = fullTag.Substring(0, fullTag.Length - 1);

                var parts = fullTag.Split(' ');
                var tagName = parts[0];

                var parameters = new Dictionary<string, string>();
                for (int i = 1; i < parts.Length; i++)
                {
                    var attributeParts = parts[i].Split('=');
                    if (attributeParts.Length == 2)
                    {
                        var key = attributeParts[0];
                        var value = attributeParts[1].Trim('"');
                        parameters[key] = value;
                    }
                }

                if (_tags.TryGetValue(tagName, out var tag))
                {
                    if (!isSelfClosingTag)
                    {
                        var nextStartTagIndex = currentContent.IndexOf($"</{tagName}", endTagIndex + 1, StringComparison.Ordinal);
                        var tagContent = currentContent.Substring(endTagIndex + 1, nextStartTagIndex - endTagIndex - 1);
                        var processedContent = Process(tagContent);
                        result += tag.Process(processedContent, parameters);
                        index = nextStartTagIndex;
                    }
                    else
                    {
                        result += tag.Process(string.Empty, parameters);
                        index = endTagIndex + 1;
                    }
                }
                else
                {
                    index = endTagIndex + 1;
                }
            }

            return result;
        }
    }
}  