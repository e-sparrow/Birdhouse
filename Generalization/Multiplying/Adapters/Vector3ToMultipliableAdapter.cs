using ESparrow.Utils.Extensions;
using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Multiplying.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Multiplying
{
    public class Vector3ToMultipliableAdapter : ToMultipliableAdapterBase<Vector3>
    {
        public Vector3ToMultipliableAdapter(Vector3 value) : base(value)
        {
            
        }

        public override IMultipliable<Vector3> Multiply(Vector3 other)
        {
            return new Vector3ToMultipliableAdapter(Value.Multiply(other));
        }

        public override IMultipliable<Vector3> Divide(Vector3 other)
        {
            return new Vector3ToMultipliableAdapter(Value.Divide(other));
        }

        public override IMultipliable<Vector3> Mod(Vector3 other)
        {
            return new Vector3ToMultipliableAdapter(Value.Mod(other));
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector3;
    }
}