using System;

namespace Birdhouse.Features.LogicSlicing.Interfaces
{
    public interface ILogicSlicer : IDisposable
    {
        ILogicSlice RegisterSlice();
        
        void Trigger();
    }
}