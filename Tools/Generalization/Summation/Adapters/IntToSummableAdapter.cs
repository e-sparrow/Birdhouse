using Birdhouse.Tools.Generalization.Summation.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Summation.Adapters
{
    public class IntToSummableAdapter : ToSummableAdapterBase<int>
    {
        public IntToSummableAdapter(int value) : base(value)
        {
            
        }

        public override ISummable<int> Plus(int other)
        {
            return new IntToSummableAdapter(Value + other);
        }

        public override ISummable<int> Minus(int other)
        {
            return new IntToSummableAdapter(Value - other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Int;
    }
}