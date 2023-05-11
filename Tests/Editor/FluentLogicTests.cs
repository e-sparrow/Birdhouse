using System.Collections.Generic;
using System.Linq;
using Birdhouse.Features.FluentLogics;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class FluentLogicTests
    {
        [Test]
        public void TestFluentLogic()
        {
            ESizeResult result;
            var list = new List<int>();
            
            CheckTooMuch();
            CheckTooFew();
            CheckOkay();

            void CheckTooMuch()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 11));
                
                ExecuteNormal();
                Assert.IsTrue(result == ESizeResult.TooMuch);
            }

            void CheckTooFew()
            {
                list.Clear();
                list.Add(0);
                
                ExecuteNormal();
                Assert.IsTrue(result == ESizeResult.TooFew);
            }

            void CheckOkay()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 5));
                
                ExecuteNormal();
                Assert.IsTrue(result == ESizeResult.Okay);
            }

            void ExecuteNormal()
            {
                if (list.Count > 10)
                {
                    NotifyTooMuch();
                }
                else if (list.Count < 5)
                {
                    NotifyTooFew();
                }
                else
                {
                    NotifyOkay();
                }
            }

            void Execute()
            {
                FluentLogic.If(() => list.Count > 10).So(NotifyTooMuch)
                    .ElseIf(() => list.Count < 5).So(NotifyTooFew)
                    .Else().So(NotifyOkay);
            }

            void NotifyTooMuch()
            {
                result = ESizeResult.TooMuch;
                Debug.Log($"It's too much values in list");
            }

            void NotifyTooFew()
            {
                result = ESizeResult.TooFew;
                Debug.Log("It's too few values in list");
            }

            void NotifyOkay()
            {
                result = ESizeResult.Okay;
                Debug.Log($"Nice, no fault");
            }
        }

        private enum ESizeResult
        {
            None,
            TooMuch,
            TooFew,
            Okay
        }
    }
}