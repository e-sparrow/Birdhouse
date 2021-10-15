using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Summation.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Summation.Adapters
{
    public class Vector2ToSummableAdapter : ToSummableAdapterBase<Vector2>
    {
        public Vector2ToSummableAdapter(Vector2 value) : base(value)
        {
            
        }

        public override ISummable<Vector2> Plus(Vector2 other)
        {
            return new Vector2ToSummableAdapter(Value + other);;
        }
        
        public override ISummable<Vector2> Minus(Vector2 other)
        {
            return new Vector2ToSummableAdapter(Value - other);;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector2;
    }
}