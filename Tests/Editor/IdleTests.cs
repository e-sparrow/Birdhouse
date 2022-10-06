using System;
using System.Collections;
using System.Globalization;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Idle;
using UnityEngine;
using UnityEngine.TestTools;

namespace Birdhouse.Tests.Editor
{
    public class IdleTests
    {
        [UnityTest]
        public IEnumerator TestOfflineController()
        {
            var idleController = new TestIdleController();
            var offlineController = new OfflineController(idleController);
            
            offlineController.BecomeOnline();
            Debug.Log($"You're {"online".WithColor(Color.green).Bold()}. Now, it's calculating reward for your idle time, bro");
            
            yield return null;
            
            offlineController.BecomeOffline();
            Debug.Log($"You're {"offline".WithColor(Color.green).Bold()} again. Come again for your reward");
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