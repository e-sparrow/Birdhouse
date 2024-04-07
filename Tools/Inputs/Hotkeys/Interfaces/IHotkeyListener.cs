using System;
using Birdhouse.Abstractions.Observables;

namespace Birdhouse.Tools.Inputs.Hotkeys.Interfaces
{
    public interface IHotkeyListener
        : IObservableValue<bool>, IDisposable
    {
        
    }
}