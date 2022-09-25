using System;
using Birdhouse.Tools.Generalization.Types.Enums;
using Birdhouse.Tools.Generalization.Types.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Generalization.Types
{
    public class Vector4GeneralizationType : IGeneralizationType
    {
        public Type Type => typeof(Vector4);
        public EGeneralizationType GeneralizationType => EGeneralizationType.Vector4;
    }
}
