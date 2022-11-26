using System.Collections.Generic;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Substitution.Enums;
using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution
{
    public static class SubstitutionExtensions
    {
        public static ISubstitutionOperator<T> AsSubstitutionOperator<T>(this IList<T> self)
        {
            var result = SubstitutionHelper.CreateSubstitutionOperator(self);
            return result;
        }

        public static ISubstitutionOperator<KeyValuePair<TKey, TValue>> AsSubstitutionOperator<TKey, TValue>
            (this IDictionary<TKey, TValue> self)
        {
            var result = SubstitutionHelper.CreateSubstitutionOperator(self);
            return result;
        }

        public static ISubstitutionMethod<T> AsCapacious<T>
            (this ISubstitutionOperator<T> self, int capacity, ESubstitutionType type)
        {
            var result = SubstitutionHelper.CreateCapaciousSubstitutionMethod(self, capacity, type);
            return result;
        }

        public static ISubstitutionController<T> AsSubstitutionController<T>
            (this ISubstitutionMethod<T> self)
        {
            var result = SubstitutionHelper.CreateSubstitutionController(self);
            return result;
        }

        public static ISubstitutionController<T> AsCapaciousSubstitutionController<T>
            (this IList<T> self, int capacity, ESubstitutionType type)
        {
            var @operator = self.AsSubstitutionOperator();
            var method = @operator.AsCapacious(capacity, type);
            
            var result = SubstitutionHelper.CreateSubstitutionController(method);
            return result;
        }
    }
}