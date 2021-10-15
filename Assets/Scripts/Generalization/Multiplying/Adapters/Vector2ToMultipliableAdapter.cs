using ESparrow.Utils.Extensions;
using ESparrow.Utils.Generalization.Multiplying.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Multiplying
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
    }
}
