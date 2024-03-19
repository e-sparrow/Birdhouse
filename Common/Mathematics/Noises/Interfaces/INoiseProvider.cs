using UnityEngine;
using Birdhouse.Abstractions.Providers.Interfaces;
using Birdhouse.Features.Processors;

namespace Birdhouse.Common.Mathematics.Noises.Interfaces
{
    public interface INoiseProvider
        : IProvider<Vector2, float>
    {
        event Evaluator<Vector2> OnProcessPosition; 
        event Evaluator<float> OnProcessValue;
    }
}