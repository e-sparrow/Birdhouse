using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Misc;
using Birdhouse.Tools.Updatables.Abstractions;

namespace Birdhouse.Tools.Updatables
{
    public sealed class UpdatableValueBuilder<T>
        : UpdatableValueBuilderBase<T>
    {
        public UpdatableValueBuilder(T value) 
            : base(value)
        {
            
        }

        public UpdatableValueBuilder(Func<T> creator) 
            : base(creator)
        {
            
        }

        protected override IFlow CreateFlow(IUpdatableValueWriter<T> writer, Func<T> creator, Func<bool> func)
        {
            var result = new UpdateFlow(writer, creator, func);
            return result;
        }

        private sealed class UpdateFlow
            : UpdateValueFlowBase<T>
        {
            public UpdateFlow(IUpdatableValueWriter<T> writer, Func<T> creator, Func<bool> func)
                : base(writer, creator, func)
            {
                
            }
        }
    }
}