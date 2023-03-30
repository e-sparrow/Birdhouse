using System;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Abstractions.Disposables
{
    public static class DisposableExtensions
    {
        public static IDisposable Combine(this IDisposable self, IDisposable other)
        {
            var disposables = self.ConcatWith(other);
            
            var composite = new DisposableComposite(disposables);
            return composite;
        }

        public static IDisposable CombineByList(this IDisposable self, IDisposable other)
        {
            if (self is DisposableList list)
            {
                list.Values.Add(other);
                return list;
            }
            
            if (other is DisposableList otherList)
            {
                otherList.Values.Add(self);
                return otherList;
            }

            var result = new DisposableList();
            
            result.Values.Add(self);
            result.Values.Add(other);

            return result;
        }
    }
}