using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Experimental.FluentLogics;
using NUnit.Framework;
using Unity.PerformanceTesting;
using Debug = UnityEngine.Debug;

namespace Birdhouse.Tests.Editor
{
    public class FluentLogicTests
    {
        [Test, Performance]
        public void TestLogicFluent() => TestLogic(ExecuteFluent);

        [Test, Performance]
        public void TestLogicNormalWay() => TestLogic(ExecuteNormalWay);

        [Test, Performance]
        public void TestResultingLogicFluent() => TestResultingLogic(GetResultFluent);

        [Test, Performance]
        public void TestResultingLogicNormalWay() => TestResultingLogic(GetResultNormalWay);

        private static void TestLogic(Action<List<int>, Action, Action, Action> action)
        {
            var result = ESizeResult.None;
            var list = new List<int>();
            
            CheckTooMuch();
            CheckTooFew();
            CheckOkay();

            void CheckTooMuch()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 11));
                
                CheckFor(ESizeResult.TooMuch);
            }

            void CheckTooFew()
            {
                list.Clear();
                list.Add(0);
                
                CheckFor(ESizeResult.TooFew);
            }

            void CheckOkay()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 5));
                
                CheckFor(ESizeResult.Okay);
            }

            void CheckFor(ESizeResult expectedResult)
            {
                action.Invoke(list, NotifyTooMuch, NotifyTooFew, NotifyOkay);
                Assert.IsTrue(result == expectedResult);
                
                Measure.Method(() => action.Invoke(list, NotifyTooMuch, NotifyTooFew, NotifyOkay)).Run();
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
        
        private static void ExecuteFluent(List<int> list, Action notifyTooMuch, Action notifyTooFew, Action notifyOkay)
        {
            FluentLogic
                .If(() => list.Count > 10).So(notifyTooMuch.Invoke)
                .ElseIf(() => list.Count < 5).So(notifyTooFew.Invoke)
                .Else().So(notifyOkay.Invoke);
        }

        private static void ExecuteNormalWay(List<int> list, Action notifyTooMuch, Action notifyTooFew, Action notifyOkay)
        {
            if (list.Count > 10)
            {
                notifyTooMuch.Invoke();
            }
            else if (list.Count < 5)
            {
                notifyTooFew.Invoke();
            }
            else
            {
                notifyOkay.Invoke();
            }
        }

        private static void TestResultingLogic(Func<List<int>, ESizeResult> func)
        {
            var list = new List<int>();
            
            CheckTooMuch();
            CheckTooFew();
            CheckOkay();

            void CheckTooMuch()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 11));
                
                CheckFor(ESizeResult.TooMuch);
            }

            void CheckTooFew()
            {
                list.Clear();
                list.Add(0);
                
                CheckFor(ESizeResult.TooFew);
            }

            void CheckOkay()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 5));
                
                CheckFor(ESizeResult.Okay);
            }

            void CheckFor(ESizeResult expectedResult)
            {
                var result = func.Invoke(list);
                Assert.IsTrue(result == expectedResult);
                
                Measure.Method(() => func.Invoke(list)).Run();
            }
        }

        private static ESizeResult GetResultFluent(List<int> list)
        {
            var result = FluentLogic<ESizeResult>
                .If(() => list.Count > 10).SoReturn(() => ESizeResult.TooMuch)
                .ElseIf(() => list.Count < 5).SoReturn(() => ESizeResult.TooFew)
                .Else().SoReturn(() => ESizeResult.Okay);

            return result;   
        }

        private static ESizeResult GetResultNormalWay(List<int> list)
        {
            return list.Count switch
            {
                > 10 => ESizeResult.TooMuch,
                < 5 => ESizeResult.TooFew,
                _ => ESizeResult.Okay
            };
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