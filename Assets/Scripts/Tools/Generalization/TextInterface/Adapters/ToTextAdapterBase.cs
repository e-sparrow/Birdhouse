using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Tools.Generalization.TextInterface.Interfaces;

namespace ESparrow.Utils.Tools.Generalization.TextInterface.Adapters
{
    public abstract class ToTextAdapterBase : IText
    {
        public abstract string Text
        {
            get;
            set;
        }
    }
}
