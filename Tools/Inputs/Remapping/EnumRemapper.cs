using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Tools.Inputs.Remapping
{
    public class EnumRemapper<TKey, TValue>
        : RemapperBase<TKey, TValue>
        where TKey : Enum
        where TValue : Enum
    {
        protected override IDictionary<TKey, TValue> GetInitialDictionary()
        {
            var result = EnumsHelper<TKey>
                .GetValues()
                .ToDictionary(value => value, value => (TValue) Convert.ChangeType(value, typeof(long)));

            return result;
        }
    }
}