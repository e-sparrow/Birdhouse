using System;
using System.Collections.Generic;

namespace Birdhouse.Abstractions.Disposables
{
    public class DisposableList : IDisposable
    {
        public List<IDisposable> Values
        {
            get;
        } = new List<IDisposable>();

        public void Dispose()
        {
            Values.ForEach(value => value.Dispose());
        }
    }
}