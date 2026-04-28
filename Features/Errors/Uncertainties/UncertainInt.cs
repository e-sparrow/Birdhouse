using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainInt
        : SerializedUncertainValueBase<int>
    {
        [SerializeField] private int origin;
        
        [SerializeField] private int positiveError;
        [SerializeField] private int negativeError;
        
        [SerializeField] private bool isPositivePercent;
        [SerializeField] private bool isNegativePercent;
        
        [SerializeField] private ErrorProviderSettings settings;
        
        public override IUncertainty<int> ToUncertainty(Random random = null) 
            => new IntUncertainty(ErrorProviderFactory.Create(settings, random), origin, negativeError, positiveError, isNegativePercent, isPositivePercent);
        
        public static implicit operator UncertainInt(int value) 
            => new UncertainInt() { origin = value, settings = ErrorProviderSettings.Uniform };
    }
}