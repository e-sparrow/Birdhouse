using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.LogicSlicing.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.LogicSlicing
{
    public class LogicSlicer : ILogicSlicer
    {
        public LogicSlicer()
        {
            _slices = new RegistryEnumerable<LogicSlice, LogicSliceWrapper>(CreateToken);
        }
        
        private readonly IRegistryEnumerable<LogicSlice, LogicSliceWrapper> _slices;

        private int _index = -1;

        public ILogicSlice RegisterSlice()
        {
            var slice = new LogicSlice(new RegistryEnumerable<Action>());
            
            var result = _slices.Register(slice);
            return result;
        }

        public void Trigger()
        {
            var isEmpty = !_slices.Any();
            if (isEmpty)
            {
                return;
            }

            _index++;

            if (_index >= _slices.Count())
            {
                _index = 0;
            }

            var slice = _slices.ElementAt(_index);
            slice.Trigger();
        }

        private static LogicSliceWrapper CreateToken(LogicSlice slice, ICollection<LogicSlice> destination)
        {
            var token = slice.AddAsDisposableTo(destination);
            
            var result = new LogicSliceWrapper(slice, token);
            return result;
        }

        public void Dispose()
        {
            _slices.Dispose();
            _index = -1;
        }
        
        private readonly struct LogicSlice 
            : ILogicSlice
        {
            public LogicSlice(IRegistryEnumerable<Action> actions)
            {
                actions ??= new RegistryEnumerable<Action>();
                _actions = actions;
            }

            private readonly IRegistryEnumerable<Action> _actions;

            public void Trigger()
            {
                foreach (var action in _actions)
                {
                    action.Invoke();
                }
            }
            
            public IDisposable RegisterAction(Action action)
            {
                var result = _actions.Register(action);
                return result;
            }

            public void Dispose()
            {
                _actions.Dispose();
            }
        }
        
        private class LogicSliceWrapper
            : ILogicSlice
        {
            public LogicSliceWrapper(LogicSlice slice, IDisposable token)
            {
                _slice = slice;
                _token = token;
            }

            private readonly LogicSlice _slice;
            private readonly IDisposable _token;

            public IDisposable RegisterAction(Action action)
            {
                var result = _slice.RegisterAction(action);
                return result;
            }
            
            public void Dispose()
            {
                _slice.Dispose();
                _token.Dispose();
            }
        }
    }
}