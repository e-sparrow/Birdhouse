using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Abstractions.Detectors.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Abstractions.Detectors
{
    public abstract class DetectorBase<T> 
        : IDetector<T>
    {
        private readonly IRegistryEnumerable<T> _banValues = new RegistryEnumerable<T>();
        private readonly IRegistryEnumerable<Predicate<T>> _banRules = new RegistryEnumerable<Predicate<T>>();

        private readonly IRegistryEnumerable<T> _exceptionValues = new RegistryEnumerable<T>();
        private readonly IRegistryEnumerable<Predicate<T>> _exceptionRules = new RegistryEnumerable<Predicate<T>>();

        protected abstract bool TryDetectInternal(Predicate<T> input, out IEnumerable<T> result);

        public IDisposable RegisterBanValue(T value)
        {
            var token = _banValues.Register(value);
            return token;
        }

        public IDisposable RegisterBanRule(Predicate<T> rule)
        {
            var token = _banRules.Register(rule);
            return token;
        }

        public IDisposable RegisterExceptionValue(T value)
        {
            var token = _exceptionValues.Register(value);
            return token;
        }

        public IDisposable RegisterExceptionRule(Predicate<T> rule)
        {
            var token = _exceptionRules.Register(rule);
            return token;
        }

        public bool TryDetect(out IEnumerable<T> output)
        {
            var list = new List<T>();

            foreach (var value in _banValues)
            {
                TryDetectInternal(item => item.Equals(value), out var bannedByValues);
                
                if (bannedByValues != null)
                {
                    list.AddRange(bannedByValues);
                }
            }

            foreach (var rule in _banRules)
            {
                TryDetectInternal(rule, out var bannedByRules);
                
                if (bannedByRules != null)
                {
                    list.AddRange(bannedByRules);
                }
            }

            var isDetected = list.Any();
            if (!isDetected)
            {
                output = Enumerable.Empty<T>();
                return false;
            }
            
            output = list.Where(IsDetected);

            var result = output.Any();
            return result;

            bool IsDetected(T value)
            {
                if (_banValues.Contains(value))
                {
                    return true;
                }

                var isBannedByRule = _banRules.Any(rule => rule.Invoke(value));
                if (isBannedByRule)
                {
                    var isExceptionByValue = _exceptionValues.Contains(value);
                    if (isExceptionByValue)
                    {
                        return false;
                    }
                
                    var isExceptionByRule = _exceptionRules.Any(rule => rule.Invoke(value));
                    if (isExceptionByRule)
                    {
                        return false;
                    }

                    return true;
                }

                return false;
            }
        }

        public void Dispose()
        {
            _banValues.Dispose();
            _banRules.Dispose();
            
            _exceptionValues.Dispose();
            _exceptionRules.Dispose();
        }
    }
}