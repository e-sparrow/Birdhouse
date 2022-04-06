using ESparrow.Utils.Conditions.Enums;

namespace ESparrow.Utils.Conditions
{
    public abstract class TypedConditionBase<T> : ConditionBase<T>
    {
        protected TypedConditionBase(EConditionType type, T origin, bool inverse = false) 
            : base(origin, inverse)
        {
            _type = type;
        }

        private readonly EConditionType _type;

        protected abstract bool Fit(T origin, T value, EConditionType type);

        protected override bool Fit(T origin, T value)
        {
            return Fit(origin, value, _type);
        }
    }
}