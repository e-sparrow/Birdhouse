using System;
using ESparrow.Utils.Generalization.Interfaces;
using ESparrow.Utils.Generalization.Types.Enums;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Types
{
    public class Vector4GeneralizationType : IGeneralizationType
    {
        public Type Type => typeof(Vector4);
        public EGeneralizationType GeneralizationType => EGeneralizationType.Vector4;
    }
}
