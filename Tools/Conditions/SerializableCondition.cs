using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Conditions.Enums;

namespace Birdhouse.Tools.Conditions
{
    public class SerializableCondition<T> : SerializableConditionBase<T>
    {
        protected override bool Fit(T origin, T value, EConditionType type)
        {
            return ConditionHelper.Check(origin, value, type);
        }
    }
}