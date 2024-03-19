using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Adapters;
using Birdhouse.Abstractions.Adapters.Interfaces;
using Birdhouse.Common.Collections;
using Birdhouse.Tools.Generalization.TextInterface.Interfaces;
using UnityEngine.UI;

namespace Birdhouse.Customization.SerializableAdapters
{
    public class TextComponentsAdapter
        : ComponentAdapterBase<IText>
    {
        //private static readonly LazyDictionary<Type, IAdapter<IText>> Adapters =
        //    new LazyDictionary<Type, IAdapter<IText>>(new Dictionary<Type, Func<IAdapter<IText>>>()
        //    {
        //        { typeof(Text), () => new Adapter<IText>()}
        //    });
        
        protected override bool TryGetAdapter(Type type, out IAdapter<IText> adapter)
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}