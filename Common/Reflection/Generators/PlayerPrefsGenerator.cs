using System;
using System.Collections.Generic;
using System.Reflection;
using Birdhouse.Tools.Identification.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Reflection.Generators
{
    /// <summary>
    /// That's more sample than something usable, but you can see how to use generators here
    /// </summary>
    public class PlayerPrefsGenerator : GeneratorBase
    {
        public PlayerPrefsGenerator(IUnifier<string> unifier)
        {
            _unifier = unifier;
        }

        private static readonly IDictionary<Type, Func<string, object>> ValueFunctions = new Dictionary<Type, Func<string, object>>()
        {
            {
                typeof(int),
                key => PlayerPrefs.GetInt(key)
            },

            {
                typeof(string),
                key => PlayerPrefs.GetString(key)
            },

            {
                typeof(bool),
                key => PlayerPrefs.GetInt(key) == 1 ? true : false
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