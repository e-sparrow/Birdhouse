using System;
using Birdhouse.Extended.Protection.PersistentData.Unity;
using Birdhouse.Experimental.FluentLogics;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class SafePrefsTests
    {
        private const string PrefsGroupName = "Test";
        
        private const string SampleKey = "SafePrefsTests Sample";
        private const int SampleValue = 69;

        private const int TestSafePrefsApplyingWithFluentLogicsMeasurementCount = 100;
        private const int TestSafePrefsApplyingWithCommonLogicsMeasurementCount = 100;

        [Test, Performance]
        public void TestSafePrefsApplyingWithFluentLogics()
        {
            Measure
                .Method(Test)
                .MeasurementCount(TestSafePrefsApplyingWithFluentLogicsMeasurementCount)
                .Run();
            
            void Test()
            {
                SafePrefs
                    .GetOrCreate(PrefsGroupName)
                    .TrySetValue(SampleKey, SampleValue)
                    .So(() => Debug.Log($"Successfully setted the \'{SampleKey}\' key to {SampleValue}"))
                    .Else()
                    .So(() => Debug.LogError($"Can't set the \'{SampleKey}\' key to {SampleValue}"));
            }
        }

        [Test, Performance]
        public void TestSafePrefsApplyingWithCommonLogics()
        {
            Measure
                .Method(Test)
                .MeasurementCount(TestSafePrefsApplyingWithCommonLogicsMeasurementCount)
                .Run();

            void Test()
            {
                var isSuccess = SafePrefs
                    .GetOrCreate(PrefsGroupName)
                    .TrySetValue(SampleKey, SampleValue);

                if (isSuccess)
                {
                    Debug.Log($"Successfully setted the \'{SampleKey}\' key to {SampleValue}");
                }
                else
                {
                    Debug.LogError($"Can't set the \'{SampleKey}\' key to {SampleValue}");
                }
            }
        }

        [Test]
        public void TestSafePrefsModificationCatching()
        {
            return;
            
            SafePrefs
                .GetOrCreate(PrefsGroupName)
                .TrySetValue(SampleKey, SampleValue)
                .So(() => Debug.Log($"Set \'{SampleKey}\' value to {SampleValue}"))
                .Else()
                .So(() => Debug.LogError($"Can't \'{SampleKey}\' value to {SampleValue}"));

            throw new NotImplementedException();
        }
    }
}