using Birdhouse.Common.Mathematics.Noises.Interfaces;
using Birdhouse.Features.Aggregators;
using UnityEngine;

namespace Birdhouse.Common.Mathematics.Noises
{
    public class PerlinNoiseProvider
        : INoiseProvider
    {
        public event Aggregation<Vector2> OnProcessPosition = value => value;
        public event Aggregation<float> OnProcessValue = value => value;
        
        public float GetValue(Vector2 position)
        {
            position = OnProcessPosition.Invoke(position);
            
            var result = Mathf.PerlinNoise(position.x, position.y);
            result = OnProcessValue.Invoke(result);
            
            return result;
        }
    }
}