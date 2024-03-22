using System.Collections.Generic;
using Birdhouse.Abstractions.Misc.Interfaces;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Abstractions.Misc
{
    public sealed class CompositeFlow
        : ICompositeFlow
    {
        private readonly ICollection<IFlow> _flows
            = new List<IFlow>();
        
        public void Initialize()
        {
            _flows.Foreach(value => value.Initialize());
        }
        
        public void Dispose()
        {
            _flows.Foreach(value => value.Dispose());
        }

        public ICompositeFlow Append(IFlow other)
        {
            _flows.Add(other);
            return this;
        }
    }
}