using System;
using System.Collections;
using System.Globalization;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Idle;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Birdhouse.Tests.Editor
{
    public class IdleTests
    {
        [Test]
        public void TestOfflineController()
        {
            var idleController = new TestIdleController();
            var offlineController = new OfflineController(idleController);
            
            Debug.Log($"You're {"online".WithColor(Color.green).Bold()}. Now, it's calculating reward for your idle time");
            offlineController.BecomeOnline();
            
            Debug.Log($"You're {"offline".WithColor(Color.green).Bold()} again. Come again for your reward");
            offlineController.BecomeOffline();
        }
        
        private class TestIdleController : IdleControllerBase
        {
            public override void IdleFor(TimeSpan time)
            {
                var seconds = (int) time.TotalSeconds;
                Debug.Log($"You was offline for a {seconds.ToString(CultureInfo.InvariantCulture).WithColor(Color.green).Bold()} seconds!");
            }
        }
    }
}