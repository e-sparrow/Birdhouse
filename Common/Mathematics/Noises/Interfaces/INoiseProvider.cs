using UnityEngine;
using Birdhouse.Abstractions.Providers;
using Birdhouse.Features.Aggregators;

namespace Birdhouse.Common.Mathematics.Noises.Interfaces
{
    public interface INoiseProvider
        : IProvider<Vector2, float>
    {
        event Aggregation<Vector2> OnProcessPosition; 
        event Aggregation<float> OnProcessValue;
    }
}