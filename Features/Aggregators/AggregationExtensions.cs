using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Features.Aggregators.Interfaces;

namespace Birdhouse.Features.Aggregators
{
    public static class AggregationExtensions
    {
        public static IDisposable AddAsDisposable<T>(this IAggregator<T> self, Aggregation<T> value)
        {
            self.OnProcess += value;
            
            var result = new CallbackDisposable(Unsubscribe);
            return result;
            
            void Unsubscribe()
            {
                self.OnProcess -= value;
            }
        }

        public static Aggregation<T> AsAggregation<T>(this IAggregator<T> self)
        {
            var result = new Aggregation<T>(self.Process);
            return result;
        }

        public static IReadOnlyAggregator<T> AsReadOnly<T>(this IAggregator<T> self)
        {
            var result = self as IReadOnlyAggregator<T>;
            return result;
        }
    }
}