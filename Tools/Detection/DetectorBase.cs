using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Detection.Interfaces;
using Birdhouse.Tools.Filtering.Interfaces;

namespace Birdhouse.Tools.Detection
{
    public abstract class DetectorBase<T> : IDetector<T>
    {
        protected abstract IEnumerable<T> DetectAll();

        public IEnumerable<T> Detect(IFilter<IEnumerable<T>, T> filter)
        {
            var notFiltered = DetectAll();
            
            var result = notFiltered.ApplyFilter(filter);
            return result;
        }
    }
}