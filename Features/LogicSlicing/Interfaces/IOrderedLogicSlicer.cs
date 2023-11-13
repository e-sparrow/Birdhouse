using System;

namespace Birdhouse.Features.LogicSlicing.Interfaces
{
    public interface IOrderedLogicSlicer : IDisposable
    {
        ILogicSlice GetOrCreateSlice(int index);

        void Trigger();
    }
}