using UnityEngine;
using UnityEngine.Serialization;

namespace Birdhouse.Features.Errors
{
    public sealed class ApproximationSample
        : MonoBehaviour
    {
        [Header("Float")] 
        [SerializeField] private float realFloatExample;
        [SerializeField] private UncertainFloat floatExample;
        
        [Header("Vectors")]
        [SerializeField] private UncertainVector2 vector2Example;
        [SerializeField] private UncertainVector3 vector3Example;
        [SerializeField] private UncertainVector4 vector4Example;
        
        [Header("Colors")]
        [SerializeField] private UncertainColor colorExample;
        [FormerlySerializedAs("hsvColorExample")] [SerializeField] private UncertainHsvColor uncertainHsvColorExample;
    }
}
