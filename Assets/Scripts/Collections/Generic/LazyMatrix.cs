using System;
using System.Linq;
using System.Collections.Generic;

namespace ESparrow.Utils.Collections.Generic
{
    public class LazyMatrix<T> : Matrix<T>
    {
        private readonly List<Lazy<Element>> _list = new List<Lazy<Element>>();
        protected override List<Element> List => _list.Where(value => value.IsValueCreated).Select(value => value.Value).ToList();
    }
}
