using System;
using System.Collections.Generic;
using System.Reflection;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Identification.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Reflection.Injectors
{
    /// <summary>
    /// That's more sample than something usable, but you can see how to use generators here
    /// </summary>
    public class PlayerPrefsInjector : InjectorBase
    {
        public PlayerPrefsInjector(IUnifier<string> unifier = null)
        {
            unifier ??= IdentificationHelper.GetBlankUnifier<string>();
            
            _unifier = unifier;
        }

        private static readonly IDictionary<Type, Func<string, object>> ValueFunctions 
            = new Dictionary<Type, Func<string, object>>()
        {
            {
                typeof(int),
                key => PlayerPrefs.GetInt(key)
            },

            {
                typeof(string),
                PlayerPrefs.GetString
            },

            {
                typeof(bool),
                key => PlayerPrefs.GetInt(key) == 1
            },

            {
                typeof(float),
                key => PlayerPrefs.GetFloat(key)
            }
        };
            
        private readonly IUnifier<string> _unifier;

        protected override bool TryGetParameterResult(ParameterInfo parameter, out object result)
        {
            result = null;
            
            var name = _unifier.Unify(parameter.Name);
            var type = parameter.ParameterType;
            
            var isFit = ValueFunctions.ContainsKey(type);
            if (isFit)
            {
                result = ValueFunctions[type].Invoke(name);
                return true;
            }

            return false;
        }
    }
}