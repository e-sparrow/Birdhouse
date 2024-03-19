using System;
using Birdhouse.Abstractions.Disposables;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Birdhouse.Common.Extensions
{
    public static class ButtonExtensions
    {
        public static IDisposable AddDisposableListener(this Button self, Action action)
        {
            var call = new UnityAction(action);
            self.onClick.AddListener(call);

            var token = new CallbackDisposable(RemoveListener);
            return token;

            void RemoveListener()
            {
                self.onClick.RemoveListener(call);
            }
        }
    }
}