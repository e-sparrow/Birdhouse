using UnityEngine;

namespace Birdhouse.Customization.SerializableAdapters.Samples
{
    public class ComponentAdapterSample 
        : MonoBehaviour
    {
        [SerializeField] private ComponentAdapter<Component> adapter;
    }
}