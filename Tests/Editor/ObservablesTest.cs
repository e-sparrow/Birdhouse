using System;
using System.Collections;
using System.Threading;
using Birdhouse.Abstractions.Observables;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Birdhouse.Tests.Editor
{
    public class ObservablesTest
    {
        [UnityTest]
        public IEnumerator TestObservableAction()
        {
            var isInvoked = false;
            
            var action = new Action(() => { });
            var observable = action.AsObservable();
            
            observable.AppendCallback(Log);

            Debug.Log("Appended callback. Waiting for delay to listen observable");
            yield return null;
            
            Debug.Log("Invoking callback...");
            observable.Invoke();
            
            Assert.IsTrue(isInvoked);
            
            void Log()
            {
                Debug.Log("Observable listened");
                isInvoked = true;
            }
        }

        [UnityTest]
        public IEnumerator TestObservableDisposable()
        {
            var source = new CancellationTokenSource();

            var isInvoked = false;
            
            var observable = source.AsObservableAction();
            observable.AppendCallback(Log);
            
            Debug.Log("Appended callback. Waiting for delay to listen observable");
            yield return null;
            
            Debug.Log("Invoking callback...");
            observable.Invoke();
            
            Assert.IsTrue(isInvoked);

            void Log()
            {
                Debug.Log("Observable listened");
                isInvoked = true;
            }
        }

        [UnityTest]
        public IEnumerator TestObservableCancellationToken()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            var isInvoked = false;
            
            var observable = token.AsObservable();
            observable.AppendCallback(Log);
            
            Debug.Log("Appended callback. Waiting for delay to listen observable");
            yield return null;
            
            Debug.Log("Invoking callback...");
            source.Cancel();
            
            Assert.IsTrue(isInvoked);

            void Log()
            {
                Debug.Log("Observable listened");
                isInvoked = true;
            }
        }

        private class DisposableSample : IDisposable
        {
            public void Dispose()
            {
                
            }
        }
    }
}