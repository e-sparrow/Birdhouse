using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Conversion;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class ConversionTests
    {
        [Test]
        public void TestNotImplementedConversion()
        {
            var boolean = new bool();
            var caught = false;

            try
            {
                Debug.Log($"Trying to convert wrong values, excepting {"ArgumentException".WithColor(Color.blue).Bold()}...");
                boolean.Convert<bool, TestConversionsType>();
            }
            catch (ArgumentException)
            {
                caught = true;
                Debug.Log($"{"Caught".WithColor(Color.green).Bold()} excepted exception!");
            }
            finally
            {
                Assert.IsTrue(caught);
            }
        }

        [Test]
        public void TestRegisteredConversion()
        {
            var conversion = new SpecificTypedConversion<bool, TestConversionsType>(Convert);
            
            var disposable = conversion.Register();
            var boolean = new bool();
            boolean.Convert<bool, TestConversionsType>();
            
            disposable.Dispose();

            TestConversionsType Convert(bool boolean)
            {
                var result = new TestConversionsType(boolean);
                return result;
            }
        }

        [Test]
        public void TestUnregisteredConversion()
        {
            TestRegisteredConversion();
            Debug.Log($"{"Disposed".WithColor(Color.green).Bold()} registration of conversion, excepting an exception...");
            TestNotImplementedConversion();
        }
        
        private class TestConversionsType
        {
            public TestConversionsType(bool value)
            {
                Debug.Log($"Created test conversion type with value {value.ToString().WithColor(Color.blue).Bold()}!");
            }
        }
    }
}