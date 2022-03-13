using System.Collections.Generic;
using ESparrow.Utils.Exceptions;
using ESparrow.Utils.Tools.Substitution;
using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;
using ESparrow.Utils.Tools.Substitution.Methods;
using ESparrow.Utils.Tools.Substitution.Operators.Adapters;

namespace ESparrow.Utils.Helpers
{
    public static class SubstitutionHelper
    {
        public static ISubstitutionOperator<T> CreateSubstitutionOperator<T>(IList<T> list)
        {
            return new ListToSubstitutionOperatorAdapter<T>(list);
        }
        
        public static ISubstitutionOperator<KeyValuePair<TKey, TValue>> CreateSubstitutionOperator<TKey, TValue>
            (IDictionary<TKey, TValue> dictionary)
        {
            return new DictionaryToSubstitutionOperatorAdapter<TKey, TValue>(dictionary);
        }

        public static ISubstitutionMethod<T> CreateSubstitutionMethod<T>
            (ISubstitutionOperator<T> substitutionOperator, ESubstitutionType type)
        {
            switch (type)
            {
                case ESubstitutionType.Forget:
                    return new ForgetSubstitutionMethod<T>(substitutionOperator);
                case ESubstitutionType.Update:
                    return new UpdateSubstitutionMethod<T>(substitutionOperator);
                default:
                    throw new WtfException("Not provided substitution type");
            }
        }

        public static ISubstitutionMethod<T> CreateCapaciousSubstitutionMethod<T>
            (int capacity, ISubstitutionMethod<T> method, ISubstitutionOperator<T> substitutionOperator)
        {
            var capacious = new CapaciousSubstitutionMethod<T>(capacity, method, substitutionOperator);
            return capacious;
        }

        public static ISubstitutionMethod<T> CreateCapaciousSubstitutionMethod<T>
            (int capacity, ISubstitutionOperator<T> substitutionOperator, ESubstitutionType type)
        {
            var method = CreateSubstitutionMethod(substitutionOperator, type);
            
            var capacious = CreateCapaciousSubstitutionMethod(capacity, method, substitutionOperator);
            return capacious;
        }

        public static ISubstitutionController<T> CreateSubstitutionController<T>(ISubstitutionMethod<T> method)
        {
            return new SubstitutionController<T>(method);
        }
    }
}