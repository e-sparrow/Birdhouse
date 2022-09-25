using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Birdhouse.Tools.Flickering.Examples
{
    public class LightFlickerExample : Flicker
    {
        [SerializeField] private Light targetLight;

        [SerializeField] private List<CharIntensityPair> charIntensityPairs;

        protected override IEnumerable<CharActionPair> Pairs => GetDefaultPairs();

        private IEnumerable<CharActionPair> GetDefaultPairs()
        {
            var pairs = charIntensityPairs.Select(value => GetPairByCharAndIntensity(value.character, value.intensity));

            return pairs.ToList();

            CharActionPair GetPairByCharAndIntensity(char character, float intensity)
            {
                return new CharActionPair(character, SetIntensity);

                void SetIntensity()
                {
                    targetLight.intensity = intensity;
                }
            }
        }

        [Serializable]
        private struct CharIntensityPair
        {
            public char character;
            public float intensity;

            public CharIntensityPair(char character, float intensity)
            {
                this.character = character;
                this.intensity = intensity;
            }
        }
    }
}
