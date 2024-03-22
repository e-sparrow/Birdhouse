using UnityEngine;
using Birdhouse.Abstractions.Providers.Interfaces;
using Birdhouse.Features.Processors;

namespace Birdhouse.Common.Mathematics.Noises.Interfaces
{
    public interface INoiseProvider
        : IProvider<Vector2, float>
    {
        event Aggregator<Vector2> OnProcessPosition; 
        event Aggregator<float> OnProcessValue;
    }
}