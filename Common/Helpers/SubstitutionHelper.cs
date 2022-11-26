using System.Collections.Generic;
using Birdhouse.Common.Exceptions;
using Birdhouse.Tools.Substitution;
using Birdhouse.Tools.Substitution.Enums;
using Birdhouse.Tools.Substitution.Interfaces;
using Birdhouse.Tools.Substitution.Methods;
using Birdhouse.Tools.Substitution.Operators.Adapters;

namespace Birdhouse.Common.Helpers
{
    public static class SubstitutionHelper
    {
        public static ISubstitutionOperator<T> CreateSubstitutionOperator<T>(IList<T> list)
        {
            var result = new ListToSubstitutionOperatorAdapter<T>(list);
            return result;
        }
        
        public static ISubstitutionOperator<KeyValuePair<TKey, TValue>> CreateSubstitutionOperator<TKey, TValue>
            (IDictionary<TKey, TValue> dictionary)
        {
            var result = new DictionaryToSubstitutionOperatorAdapter<TKey, TValue>(dictionary);
            return result;
        }

        public static ISubstitutionMethod<T> CreateSubstitutionMethod<T>
            (ISubstitutionOperator<T> substitutionOperator, ESubstitutionType type)
        {
            switch (type)
            {
                case ESubstitutionType.Forget:
                    var forgetMethod = new ForgetSubstitutionMethod<T>(substitutionOperator);
                    return forgetMethod;
                    
                case ESubstitutionType.Update:
                    var substitutionMethod = new UpdateSubstitutionMethod<T>(substitutionOperator);
                    return substitutionMethod;
                    
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
            var result = new SubstitutionController<T>(method);
            return result;
        }
    }
}