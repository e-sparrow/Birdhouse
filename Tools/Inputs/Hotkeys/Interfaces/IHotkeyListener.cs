using System;
using Birdhouse.Abstractions.Observables.Interfaces;

namespace Birdhouse.Tools.Inputs.Hotkeys.Interfaces
{
    public interface IHotkeyListener
        : IObservableValue<bool>, IDisposable
    {
        
    }
}