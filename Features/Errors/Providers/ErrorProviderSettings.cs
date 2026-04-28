using System;
using UnityEngine;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class ErrorProviderSettings
    {
        [SerializeField] private EErrorProvider type = EErrorProvider.Normal;
        [SerializeField] private float sigma = 0.33f;
        [SerializeField] private float peak = 0f;
        [SerializeField] private float lambda = 2f;
        [SerializeField] private AnimationCurve curve;
    
        public static ErrorProviderSettings Uniform => new ErrorProviderSettings() { type = EErrorProvider.Uniform };
        public static ErrorProviderSettings DefaultNormal => new ErrorProviderSettings() { type = EErrorProvider.Normal };
        public static ErrorProviderSettings DefaultTriangle => new ErrorProviderSettings() { type = EErrorProvider.Triangle };
        public static ErrorProviderSettings DefaultExponential => new ErrorProviderSettings() { type = EErrorProvider.Exponential };
        
        public EErrorProvider Type { get => type; set => type = value; }
        public float Sigma { get => sigma; set => sigma = Mathf.Clamp01(value); }
        public float Peak { get => peak; set => peak = Mathf.Clamp(value, -1f, 1f); }
        public float Lambda { get => lambda; set => lambda = Mathf.Max(0.1f, value); }
        public AnimationCurve Curve { get => curve; set => curve = value; }
    }
}