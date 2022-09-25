using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
{
    public class IntToMultipliableAdapter : ToMultipliableAdapterBase<int>
    {
        public IntToMultipliableAdapter(int value) : base(value)
        {
            
        }

        public override IMultipliable<int> Multiply(int other)
        {
            return new IntToMultipliableAdapter(Value * other);
        }

        public override IMultipliable<int> Divide(int other)
        {
            return new IntToMultipliableAdapter(Value / other);
        }

        public override IMultipliable<int> Mod(int other)
        {
            return new IntToMultipliableAdapter(Value % other);
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Int;
    }
}