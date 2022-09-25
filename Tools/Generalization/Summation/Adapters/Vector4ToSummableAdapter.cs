﻿using Birdhouse.Tools.Generalization.Summation.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Generalization.Summation.Adapters
{
    public class Vector4ToSummableAdapter : ToSummableAdapterBase<Vector4>
    {
        public Vector4ToSummableAdapter(Vector4 value) : base(value)
        {
            
        }

        public override ISummable<Vector4> Plus(Vector4 other)
        {
            return new Vector4ToSummableAdapter(Value + other);
        }
        
        public override ISummable<Vector4> Minus(Vector4 other)
        {
            return new Vector4ToSummableAdapter(Value - other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector4;
    }
}