using System.Collections.Generic;
using Birdhouse.Tools.Filtering.Routine;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class FilteringTests
    {
        [Test]
        public void TestLevenshteinFilter()
        {
            var list = new List<string>()
            {
                "Cucumber",
                "Potato",
                "Tomato",
                "Peanut",
                "Apple",
                "Pot",
                "Tim",
                "iPhone",
                "Android",
                "Droid",
                "Rod",
                "Hot",
                "Matt",
                "Plat",
                "Crab",
                "Hedgehog",
                "Hog",
                "Dog",
                "Hop"
            };

            var hogFilter = new PriorityBasedLevenshteinFilter("Hog", 10);
            var hogResult = hogFilter.Filtrate(list);
            foreach (var result in hogResult)
            {
                Debug.Log(result);
            }
        }   
    }
}