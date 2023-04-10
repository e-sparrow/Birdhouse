using System.Collections.Generic;
using Birdhouse.Common.Exceptions;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Injectors;
using Birdhouse.Common.Reflection.Injectors.Attributes;
using Birdhouse.Common.Reflection.Injectors.Interfaces;
using Birdhouse.Tools.Identification;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class InjectorTests
    {
        [Test]
        public void TestPlayerPrefsInjector()
        {
            var unifier = new Unifier<string>(name => $"BirdhouseTests/{name}");
            
            PlayerPrefs.SetInt(unifier.Unify("exampleBool"), 1);
            PlayerPrefs.SetInt(unifier.Unify("exampleInt"), 666);
            PlayerPrefs.SetFloat(unifier.Unify("exampleFloat"), 4.20f);
            PlayerPrefs.SetString(unifier.Unify("exampleString"), "That's best example of PlayerPrefs value ever!");
            
            if (InjectorHelper.TryInjectFromPlayerPrefs<PlayerPrefsTarget>(out var value, unifier))
            {
                value.Log();
            }
            else
            {
                throw new WtfException($"{TestConstants.MessagePrefix} GeneratorTests/TestPlayerPrefsGenerator failed");
            }
        }

        [Test]
        public void TestParametersInjector()
        {
            var unifier = IdentificationHelper.GetUpperInvariantCaseUnifier();

            var parameter = new InjectionParameter("Injection parameter");
            var parameters = new List<IInjectable>()
            {
                new IdInjectable<string>("stringValue", "That's value of IdInjectable parameter".AsFunc()),
                new NamedInjectable<int>("intValue", 666.AsFunc(), unifier),
                new TypedInjectable<InjectionParameter>(parameter.AsFunc())
            };
                
            var injector = new ParametersInjector(parameters);
            if (injector.TryInject<InjectionTarget>(out var value))
            {
                value.Log();
            }
            else
            {
                throw new WtfException($"Can not inject to {typeof(InjectionTarget)}");
            }
        }

        private class PlayerPrefsTarget
        {
            public PlayerPrefsTarget(bool exampleBool, int exampleInt, float exampleFloat, string exampleString)
            {
                _exampleBool = exampleBool;
                _exampleInt = exampleInt;
                _exampleFloat = exampleFloat;
                _exampleString = exampleString;
            }

            private readonly bool _exampleBool;
            private readonly int _exampleInt;
            private readonly float _exampleFloat;
            private readonly string _exampleString;

            public void Log()
            {
                var message = $"{TestConstants.MessagePrefix} Created player prefs target by injector... \n" +
                              $"exampleBool value = {_exampleBool} \n" +
                              $"exampleInt value = {_exampleInt} \n" +
                              $"exampleFloat value = {_exampleFloat} \n" +
                              $"exampleString value = {_exampleString}";
                
                Debug.Log(message);
            }
        }

        private class InjectionTarget
        {
            public InjectionTarget
            (
                [InjectableId("stringValue")] string stringValue, 
                int intValue, 
                InjectionParameter parameter
            )
            {
                _stringValue = stringValue;
                _intValue = intValue;
                _parameter = parameter;
            }

            private readonly string _stringValue;
            private readonly int _intValue;
            private readonly InjectionParameter _parameter;

            public void Log()
            {
                var message = $"{TestConstants.MessagePrefix} Injected values: \n" +
                              $"stringValue = {_stringValue}\n" +
                              $"intValue = {_intValue}\n" +
                              $"Also it have <color=green>InjectionParameter</color> with message: {_parameter.Message}";
                
                Debug.Log(message);
            }
        }

        private class InjectionParameter
        {
            public InjectionParameter(string message)
            {
                Message = message;
            }
            
            public string Message
            {
                get;
            }
        }
    }
}