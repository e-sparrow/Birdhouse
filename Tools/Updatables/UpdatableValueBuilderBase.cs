using System;
using Birdhouse.Abstractions.Misc;
using Birdhouse.Tools.Updatables.Abstractions;

namespace Birdhouse.Tools.Updatables
{
    public abstract class UpdatableValueBuilderBase<T>
    {
        protected UpdatableValueBuilderBase(Func<T> creator)
        {
            _creator = creator;
            _result = new UpdatableValue<T>(creator.Invoke());
        }
        
        protected UpdatableValueBuilderBase(T value)
            : this(() => value)
        {
            
        }

        private readonly Func<T> _creator;

        private readonly IUpdatableValue<T> _result;

        protected abstract IFlow CreateFlow(IUpdatableValueWriter<T> writer, Func<T> creator, Func<bool> func);
        
        public UpdatableValueBuilderBase<T> WithFlow(Func<bool> func, out IFlow result)
        {
            result = CreateFlow(_result, _creator, func);
            return this;
        }

        public UpdatableValueBuilderBase<T> WithWriter(out IUpdatableValueWriter<T> result)
        {
            result = _result;
            return this;
        }

        public UpdatableValueBuilderBase<T> AsLazy()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyUpdatableValue<T> BuildReadOnly()
        {
            return _result;
        }

        public IUpdatableValue<T> Build()
        {
            return _result;
        }
    }
}