using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Multiplying.Adapters
{
    public abstract class ToMultipliableAdapterBase<TSelf, TOther> : IMultipliable<TSelf, TOther>
    {
        protected ToMultipliableAdapterBase(TSelf value)
        {
            Value = value;
        }
        
        public abstract IMultipliable<TSelf, TOther> Multiply(TOther other);
        public abstract IMultipliable<TSelf, TOther> Divide(TOther other);
        public abstract IMultipliable<TSelf, TOther> Mod(TOther other);

        public TSelf Value 
        { 
            get; 
            set;
        }

        public abstract EGeneralizationType GeneralizationType
        {
            get;
        }

        public static ToMultipliableAdapterBase<TSelf, TOther> operator *(ToMultipliableAdapterBase<TSelf, TOther> left,
            TOther right)
        {
            return left.Multiply(right) as ToMultipliableAdapterBase<TSelf, TOther>;
        }

        public static ToMultipliableAdapterBase<TSelf, TOther> operator /(ToMultipliableAdapterBase<TSelf, TOther> left,
            TOther right)
        {
            return left.Divide(right) as ToMultipliableAdapterBase<TSelf, TOther>;
        }

        public static ToMultipliableAdapterBase<TSelf, TOther> operator %(ToMultipliableAdapterBase<TSelf, TOther> left,
            TOther right)
        {
            return left.Mod(right) as ToMultipliableAdapterBase<TSelf, TOther>;
        }
    }

    public abstract class ToMultipliableAdapterBase<T> : IMultipliable<T>
    {
        protected ToMultipliableAdapterBase(T value)
        {
            Value = value;
        }
        
        public abstract IMultipliable<T> Multiply(T other);
        public abstract IMultipliable<T> Divide(T other);
        public abstract IMultipliable<T> Mod(T other);

        public T Value 
        { 
            get; 
            set;
        }

        public abstract EGeneralizationType GeneralizationType
        {
            get;
        }

        public static ToMultipliableAdapterBase<T> operator *(ToMultipliableAdapterBase<T> left,
            T right)
        {
            return left.Multiply(right) as ToMultipliableAdapterBase<T>;
        }

        public static ToMultipliableAdapterBase<T> operator /(ToMultipliableAdapterBase<T> left,
            T right)
        {
            return left.Divide(right) as ToMultipliableAdapterBase<T>;
        }

        public static ToMultipliableAdapterBase<T> operator %(ToMultipliableAdapterBase<T> left,
            T right)
        {
            return left.Mod(right) as ToMultipliableAdapterBase<T>;
        }
    }
}
