using Birdhouse.Common.Mathematics.Noises.Interfaces;
using Birdhouse.Features.Processors;
using UnityEngine;

namespace Birdhouse.Common.Mathematics.Noises
{
    public class PerlinNoiseProvider
        : INoiseProvider
    {
        public event Aggregator<Vector2> OnProcessPosition = value => value;
        public event Aggregator<float> OnProcessValue = value => value;
        
        public float GetValue(Vector2 position)
        {
            position = OnProcessPosition.Invoke(position);
            
            var result = Mathf.PerlinNoise(position.x, position.y);
            result = OnProcessValue.Invoke(result);
            
            return result;
        }
    }
}