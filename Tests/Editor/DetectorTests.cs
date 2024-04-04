using System.Collections.Generic;
using System.Text;
using Birdhouse.Abstractions.Detectors;
using Birdhouse.Common.Extensions;
using Birdhouse.Extended.Protection.Detector;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class DetectorTests
    {
        private const int TestWindowDetectorMeasurementCount = 100;
        
        private static readonly IEnumerable<string> BannedWindowRegexes = new []
        {
            "(?i)(cheat(?:| )engine)"
        };

        [Test, Performance]
        public void TestWindowDetector()
        {
            Measure
                .Method(Test)
                .MeasurementCount(TestWindowDetectorMeasurementCount)
                .Run();
            
            void Test()
            {
                var windowNameDetector = new WindowNameDetector();

                foreach (var pattern in BannedWindowRegexes)
                {
                    windowNameDetector.RegisterBanRegex(pattern);
                }

                if (windowNameDetector.TryDetect(out var forbiddenWindows))
                {
                    var builder = new StringBuilder($"Ahtung! Detected some forbidden windows. See details below:")
                        .AppendLine()
                        .AppendLine($"Forbidden windows: ")
                        .Append(string.Join(", ", forbiddenWindows)
                            .Bold()
                            .WithColor(Color.red));

                    Debug.LogError(builder.ToString());
                }
            }
        }
    }
}