using System;
using Birdhouse.Common.Exceptions;
using Birdhouse.Common.Reflection.Injectors;
using Birdhouse.Tools.Identification;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class GeneratorTests
    {
        [Test]
        public void TestPlayerPrefsGenerator()
        {
            var unifier = new Unifier<string>(name => $"BirdhouseTests/{name}");
            
            PlayerPrefs.SetInt(unifier.Unify("exampleBool"), 1);
            PlayerPrefs.SetInt(unifier.Unify("exampleInt"), 666);
            PlayerPrefs.SetFloat(unifier.Unify("exampleFloat"), 4.20f);
            PlayerPrefs.SetString(unifier.Unify("exampleString"), "That's best example of PlayerPrefs value ever!");
            
            var generator = new PlayerPrefsInjector(unifier);
            if (generator.TryInject(typeof(PlayerPrefsTarget), out var value))
            {
                var result = (PlayerPrefsTarget) value;
                result.Log();
            }
            else
            {
                throw new WtfException($"{TestsConstants.MessagePrefix} GeneratorTests/TestPlayerPrefsGenerator failed");
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
                var message = $"<b><color=red>BirdhouseTests</color></b> Created player prefs target by generator... \n" +
                              $"exampleBool value = {_exampleBool} \n" +
                              $"exampleInt value = {_exampleInt} \n" +
                              $"exampleFloat value = {_exampleFloat} \n" +
                              $"exampleString value = {_exampleString}";
                
                Debug.Log(message);
            }
        }
    }
}