using System.Collections.Generic;
using Birdhouse.Features.LogicSlicing.Interfaces;

namespace Birdhouse.Features.LogicSlicing
{
    public class OrderedLogicSlicer : IOrderedLogicSlicer
    {
        private readonly ILogicSlicer _slicer = new LogicSlicer();
        private readonly IList<ILogicSlice> _slices = new List<ILogicSlice>();

        public ILogicSlice GetOrCreateSlice(int index)
        {
            var count = _slices.Count;
            if (index >= count)
            {
                var remainder = index - count + 1;
                for (var i = 0; i < remainder; i++)
                {
                    var slice = _slicer.RegisterSlice();
                    _slices.Add(slice);
                }
            }

            var result = _slices[index];
            return result;
        }

        public void Trigger()
        {
            _slicer.Trigger();
        }

        public void Dispose()
        {
            _slicer.Dispose();
            _slices.Clear();
        }
    }
}