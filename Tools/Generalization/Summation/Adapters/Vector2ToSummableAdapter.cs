using Birdhouse.Tools.Generalization.Summation.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;
using UnityEngine;

namespace Birdhouse.Tools.Generalization.Summation.Adapters
{
    public class Vector2ToSummableAdapter : ToSummableAdapterBase<Vector2>
    {
        public Vector2ToSummableAdapter(Vector2 value) : base(value)
        {
            
        }

        public override ISummable<Vector2> Plus(Vector2 other)
        {
            return new Vector2ToSummableAdapter(Value + other);
        }
        
        public override ISummable<Vector2> Minus(Vector2 other)
        {
            return new Vector2ToSummableAdapter(Value - other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Vector2;
    }
}