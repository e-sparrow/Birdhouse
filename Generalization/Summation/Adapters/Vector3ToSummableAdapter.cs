using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Summation.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Summation.Adapters
{
    public class Vector3ToSummableAdapter : ToSummableAdapterBase<Vector3>
    {
        public Vector3ToSummableAdapter(Vector3 value) : base(value)
        {
            
        }

        public override ISummable<Vector3> Plus(Vector3 other)
        {
            return new Vector3ToSummableAdapter(Value + other);
        }
        
        public override ISummable<Vector3> Minus(Vector3 other)
        {
            return new Vector3ToSummableAdapter(Value - other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector3;
    }
}