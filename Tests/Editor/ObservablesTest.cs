using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Observables;
using Birdhouse.Common.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class ObservablesTest
    {
        [Test]
        public void TestObservableAction()
        {
            var isInvoked = false;
            
            var action = new Action(() => { });
            var observable = action.AsObservable();
            
            observable.AppendCallback(Log);

            Debug.Log("Appended callback. Waiting for delay to listen observable");
            Task.Delay(100).Sync();
            
            Debug.Log("Invoking callback...");
            observable.Invoke();
            
            Assert.IsTrue(isInvoked);
            
            void Log()
            {
                Debug.Log("Observable listened");
                isInvoked = true;
            }
        }

        [Test]
        public void TestObservableDisposable()
        {
            var source = new CancellationTokenSource();

            var isInvoked = false;
            
            var observable = source.AsObservableAction();
            observable.AppendCallback(Log);
            
            Debug.Log("Appended callback. Waiting for delay to listen observable");
            Task.Delay(100).Sync();

            Debug.Log("Invoking callback...");
            observable.Invoke();
            
            Assert.IsTrue(isInvoked);

            void Log()
            {
                Debug.Log("Observable listened");
                isInvoked = true;
            }
        }

        [Test]
        public void TestObservableCancellationToken()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            var isInvoked = false;
            
            var observable = token.AsObservable();
            observable.AppendCallback(Log);
            
            Debug.Log("Appended callback. Waiting for delay to listen observable");
            Task.Delay(100).Sync();
            
            Debug.Log("Invoking callback...");
            source.Cancel();
            
            Assert.IsTrue(isInvoked);

            void Log()
            {
                Debug.Log("Observable listened");
                isInvoked = true;
            }
        }
    }
}