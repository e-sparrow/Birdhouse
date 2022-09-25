using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Conditions.Enums;

namespace Birdhouse.Tools.Conditions
{
    public class TypedCondition<T> : TypedConditionBase<T>
    {
        public TypedCondition(EConditionType type, T origin, bool inverse = false) : base(type, origin, inverse)
        {

        }

        protected override bool Fit(T origin, T value, EConditionType type)
        {
            return ConditionHelper.Check(origin, value, type);
        }
    }
}