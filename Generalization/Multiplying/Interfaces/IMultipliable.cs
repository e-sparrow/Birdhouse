using ESparrow.Utils.Generalization.Interfaces;

namespace ESparrow.Utils.Generalization.Multiplying.Interfaces
{
    public interface IMultipliable<TSelf, in TOther> : IGeneralizationAdapter
    {
        IMultipliable<TSelf, TOther> Multiply(TOther other);
        IMultipliable<TSelf, TOther> Divide(TOther other);

        IMultipliable<TSelf, TOther> Mod(TOther other);

        TSelf Value
        {
            get;
            set;
        }
    }

    public interface IMultipliable<T> : IGeneralizationAdapter
    {
        IMultipliable<T> Multiply(T other);
        IMultipliable<T> Divide(T other);

        IMultipliable<T> Mod(T other);

        T Value
        {
            get;
            set;
        }
    }
}
