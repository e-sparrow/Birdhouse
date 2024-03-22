using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Features.Processors.Interfaces;

namespace Birdhouse.Features.Processors
{
    public static class ProcessorExtensions
    {
        public static IDisposable AddAsDisposable<T>(this IProcessor<T> self, Aggregator<T> value)
        {
            self.OnProcess += value;
            
            var result = new CallbackDisposable(Unsubscribe);
            return result;
            
            void Unsubscribe()
            {
                self.OnProcess -= value;
            }
        }

        public static Aggregator<T> AsEvaluator<T>(this IProcessor<T> self)
        {
            var result = new Aggregator<T>(self.Process);
            return result;
        }
    }
}