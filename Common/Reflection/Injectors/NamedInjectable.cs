using System;
using System.Reflection;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Identification;
using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Common.Reflection.Injectors
{
    public class NamedInjectable<T> : InjectableBase
    {
        public NamedInjectable(string name, Func<T> valueFunction, IUnifier<string> unifier = null)
        {
            unifier ??= IdentificationHelper.GetBlankUnifier<string>();
            
            _name = name;
            _valueFunction = valueFunction;
            _unifier = unifier;
        }

        private readonly string _name;
        private readonly Func<T> _valueFunction;
        private readonly IUnifier<string> _unifier;

        public override bool IsFit(ParameterInfo parameter)
        {
            if (parameter.ParameterType != typeof(T))
            {
                return false;
            }

            var parameterName = _unifier.Unify(parameter.Name);
            var name = _unifier.Unify(_name);

            var result = parameterName == name;
            return result;
        }

        public override object GetValue()
        {
            var result = _valueFunction.Invoke();
            return result;
        }
    }
}