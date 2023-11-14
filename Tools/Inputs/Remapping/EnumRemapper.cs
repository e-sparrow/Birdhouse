using System;
using System.Collections.Generic;

namespace Birdhouse.Tools.Inputs.Remapping
{
    public class EnumRemapper<TKey, TValue>
        : RemapperBase<TKey, TValue>
        where TKey : Enum
    {
        public EnumRemapper(IDictionary<TKey, TValue> initialValues)
        {
            _initialValues = initialValues;
        }

        private readonly IDictionary<TKey, TValue> _initialValues;

        protected override IDictionary<TKey, TValue> GetInitialDictionary()
        {
            return _initialValues;
        }
    }
}