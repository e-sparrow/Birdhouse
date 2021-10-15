using ESparrow.Utils.Extensions;
using ESparrow.Utils.Generalization.Multiplying.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Multiplying
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
    }
}