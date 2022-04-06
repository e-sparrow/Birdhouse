using ESparrow.Utils.Conditions.Enums;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Conditions
{
    public class SerializableCondition<T> : SerializableConditionBase<T>
    {
        protected override bool Fit(T origin, T value, EConditionType type)
        {
            return ConditionHelper.Check(origin, value, type);
        }
    }
}