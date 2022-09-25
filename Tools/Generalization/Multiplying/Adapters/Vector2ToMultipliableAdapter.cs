using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
{
    public class Vector2ToMultipliableAdapter : ToMultipliableAdapterBase<Vector2>
    {
        public Vector2ToMultipliableAdapter(Vector2 value) : base(value)
        {
            
        }

        public override IMultipliable<Vector2> Multiply(Vector2 other)
        {
            return new Vector2ToMultipliableAdapter(Value * other);
        }

        public override IMultipliable<Vector2> Divide(Vector2 other)
        {
            return new Vector2ToMultipliableAdapter(Value / other);
        }

        public override IMultipliable<Vector2> Mod(Vector2 other)
        {
            return new Vector2ToMultipliableAdapter(Value.Mod(other));
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector2;
    }
}
