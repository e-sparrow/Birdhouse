using System;

namespace Birdhouse.Features.LogicSlicing.Interfaces
{
    public interface ILogicSlice : IDisposable
    {
        IDisposable RegisterAction(Action action);
    }
}