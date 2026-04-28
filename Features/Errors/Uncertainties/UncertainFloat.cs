using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainFloat 
        : SerializedUncertainValueBase<float>
    {
        [SerializeField] private float origin;
        
        [SerializeField] private float negativeError;
        [SerializeField] private float positiveError;
        
        [SerializeField] private bool isNegativePercent;
        [SerializeField] private bool isPositivePercent;
        
        [SerializeField] private ErrorProviderSettings errorProviderSettings;
        
        public float Origin { get => origin; set => origin = value; }
        
        public float NegativeError { get => negativeError; set => negativeError = Mathf.Max(0f, value); }
        public float PositiveError { get => positiveError; set => positiveError = Mathf.Max(0f, value); }
        
        public bool IsNegativePercent { get => isNegativePercent; set => isNegativePercent = value; }
        public bool IsPositivePercent { get => isPositivePercent; set => isPositivePercent = value; }
        

        public ErrorProviderSettings ErrorProviderSettings
        {
            get => errorProviderSettings ??= ErrorProviderSettings.Uniform;
            set => errorProviderSettings = value ?? ErrorProviderSettings.Uniform;
        }

        public override IUncertainty<float> ToUncertainty(Random random = null) 
            => new FloatUncertainty(ErrorProviderFactory.Create(errorProviderSettings, random), origin, negativeError, positiveError, isNegativePercent, isPositivePercent);

        public static implicit operator UncertainFloat(float value) 
            => new UncertainFloat() { origin = value, errorProviderSettings = ErrorProviderSettings.Uniform };
    }
}