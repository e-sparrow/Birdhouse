using System;
using Birdhouse.Tools.Inputs.AnyKey.Interfaces;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Ticks.Unity;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public static class UnityInputHelper
    {
        public static readonly Lazy<IPressureStateProvider<KeyCode>> KeyCodeStateProvider =
            new Lazy<IPressureStateProvider<KeyCode>>(() => new KeyCodePressureStateProvider());
        
        public static readonly Lazy<IPressureStateProvider<string>> ButtonStateProvider =
            new Lazy<IPressureStateProvider<string>>(() => new ButtonPressureStateProvider());
        
        public static readonly Lazy<IPressureStateProvider<int>> MouseStateProvider =
            new Lazy<IPressureStateProvider<int>>(() => new MousePressureStateProvider());

        public static readonly Lazy<IAnyKeyListener<KeyCode>> AnyKeyListener =
            new Lazy<IAnyKeyListener<KeyCode>>(CreateDefaultAnyKeyListener);

        private static IAnyKeyListener<KeyCode> CreateDefaultAnyKeyListener()
        {
            var result = new UnityAnyKeyListener
                (KeyCodeStateProvider.Value, UnityTicksHelper.UpdateProvider);
            
            return result;
        }
    }
}