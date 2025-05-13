using System.Collections.Generic;
using Birdhouse.Tools.Strings.Abstractions;
using UnityEngine;

namespace Birdhouse.Tools.Strings.Samples
{
    public sealed class TagPreprocessorSample
        : MonoBehaviour
    {
        [ContextMenu("Test")]
        private void Test()
        {
            var preprocessor = new TagPreprocessor();
            preprocessor.RegisterTag("name", new NameTag("Женёк"));
            preprocessor.RegisterTag("lower", new LowerTag());
            
            Debug.Log(preprocessor.Process("Имя: <lower name=пидор><name/></lower>"));
        }

        private sealed class NameTag
            : ITag
        {
            public NameTag(string name)
            {
                _name = name;
            }

            private readonly string _name;

            public string Process(string input, IDictionary<string, string> parameters = null)
            {
                return _name;
            }
        }

        private sealed class LowerTag
            : ITag
        {
            public string Process(string input, IDictionary<string, string> parameters = null)
            {
                Debug.Log($"Processing lower tag with input: {input}. Parameters: ");
                
                foreach (var parameter in parameters)
                {
                    Debug.Log($"{parameter.Key}: {parameter.Value}");
                }
                
                return input.ToLower();
            }
        }
    }
}