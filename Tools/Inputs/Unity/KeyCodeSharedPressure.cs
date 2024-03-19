using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public class KeyCodeSharedPressure
        : ISharedPressure<KeyCode>
    {
        public KeyCodeSharedPressure(IEnumerable<KeyCode> keys)
        {
            Keys = keys;
        }
        
        public KeyCodeSharedPressure(params KeyCode[] keys)
        {
            Keys = keys;
        }

        public IEnumerable<KeyCode> Keys
        {
            get;
        }

        public static explicit operator KeyCodeSharedPressure(KeyCode keyCode)
        {
            var result = new KeyCodeSharedPressure(keyCode.AsSingleEnumerable());
            return result;
        }
        
        public static KeyCodeSharedPressure operator |(KeyCodeSharedPressure self, KeyCode other)
        {
            var result = new KeyCodeSharedPressure(self.Keys.ConcatWith(other));
            return result;
        }
    }
}