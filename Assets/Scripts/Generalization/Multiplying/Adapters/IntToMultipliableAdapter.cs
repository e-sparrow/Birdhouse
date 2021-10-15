using ESparrow.Utils.Generalization.Multiplying.Interfaces;

namespace ESparrow.Utils.Generalization.Multiplying
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
    }
}