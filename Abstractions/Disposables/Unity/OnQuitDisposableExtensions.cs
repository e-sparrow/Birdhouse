using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Abstractions.Disposables.Unity
{
    public static class OnQuitDisposableExtensions
    {
        private static readonly Lazy<ICollection<IDisposable>> OnQuitDisposables 
            = new Lazy<ICollection<IDisposable>>(() => new List<IDisposable>());
        
        public static IDisposable DisposeOnQuit(this IDisposable self)
        {
            OnQuitDisposables.Value.Add(self);
            return self;
        }
        
        [RuntimeInitializeOnLoadMethod]
        static void Initialize() => Application.quitting += HandleQuit;
        
        static void HandleQuit()
        {
            Application.quitting -= HandleQuit;
            
            OnQuitDisposables.Value.Foreach(value => value.Dispose());
            OnQuitDisposables.Value.Clear();
        }
    }
}