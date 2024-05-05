using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Abstractions.Disposables;
namespace Birdhouse.Tools.Signals
{
    public class SignalBus<TBase>
    {
        private readonly IDictionary<Type, ICollection<Action<object>>> _handlers 
            = new Dictionary<Type, ICollection<Action<object>>>(); 
        
        public void Fire<T>(T argument)
            where T : TBase
        {
            var hasHandlers = _handlers.TryGetValue(typeof(T), out var handlers);
            if (hasHandlers)
            {
                foreach (var handler in handlers)
                {
                    handler.Invoke(argument);
                }
            }
        }

        public IDisposable Subscribe<T>(Action<T> handler)
            where T : TBase
        {
            var result = new Action<object>(value => handler.Invoke((T) value));
            
            var hasHandlers = _handlers.TryGetValue(typeof(T), out var handlers);
            if (hasHandlers)
            {
                handlers.Add(result);
            }
            else
            {
                handlers = new List<Action<object>>();
                handlers.Add(result);
                
                _handlers[typeof(T)] = handlers;
            }
            
            var token = new CallbackDisposable(Remove);
            return token;

            void Remove()
            {
                handlers.Remove(result);
                if (!handlers.Any())
                {
                    _handlers.Remove(typeof(T));
                }
            }
        }
    }
    
    public sealed class SignalBus 
        : SignalBus<object>
    {
    
    }
}