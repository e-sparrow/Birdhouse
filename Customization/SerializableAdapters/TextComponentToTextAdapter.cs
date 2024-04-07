using Birdhouse.Abstractions.Adapters;
using Birdhouse.Tools.Generalization.TextInterface.Interfaces;
using UnityEngine.UI;

namespace Birdhouse.Customization.SerializableAdapters
{
    public class TextComponentToTextAdapter
        : IAdapter<IText>
    {
        
        
        public bool TryAdapt(object value, out IText result)
        {
            throw new System.NotImplementedException();
        }
    }
}