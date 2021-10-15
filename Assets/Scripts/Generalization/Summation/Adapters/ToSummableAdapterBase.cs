using System.Collections.Generic;
using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Generalization.Summation.Adapters
{
    public abstract class ToSummableAdapterBase<T> : ISummable<T>
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            
            return obj.GetType() == GetType() && Equals((ISummable<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }
        
        private bool Equals(ISummable<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        protected ToSummableAdapterBase(T value)
        {
            Value = value;
        }

        public abstract ISummable<T> Plus(T other);
        public abstract ISummable<T> Minus(T other);

        public T Value
        {
            get;
            set;
        }

        public static ToSummableAdapterBase<T> operator +(ToSummableAdapterBase<T> left, ToSummableAdapterBase<T> right)
        {
            return left.Plus(right.Value) as ToSummableAdapterBase<T>;
        }
        
        public static ToSummableAdapterBase<T> operator +(ToSummableAdapterBase<T> left, T right)
        {
            return left.Plus(right) as ToSummableAdapterBase<T>;
        }

        public static ToSummableAdapterBase<T> operator -(ToSummableAdapterBase<T> left, ToSummableAdapterBase<T> right)
        {
            return left.Minus(right.Value) as ToSummableAdapterBase<T>;
        }
        
        public static ToSummableAdapterBase<T> operator -(ToSummableAdapterBase<T> left, T right)
        {
            return left.Minus(right) as ToSummableAdapterBase<T>;
        }
    }
}
