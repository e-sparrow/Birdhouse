using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
{
    public class Vector4ToMultipliableAdapter : ToMultipliableAdapterBase<Vector4>
    {
        public Vector4ToMultipliableAdapter(Vector4 value) : base(value)
        {
            
        }

        public override IMultipliable<Vector4> Multiply(Vector4 other)
        {
            return new Vector4ToMultipliableAdapter(Value.Multiply(other));
        }

        public override IMultipliable<Vector4> Divide(Vector4 other)
        {
            return new Vector4ToMultipliableAdapter(Value.Divide(other));
        }

        public override IMultipliable<Vector4> Mod(Vector4 other)
        {
            return new Vector4ToMultipliableAdapter(Value.Mod(other));
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector4;
    }
}