using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Collections.Generic;

namespace Demos
{
    public class SerializationTest : MonoBehaviour
    {
        [SerializeField] private EnumValueCollection<TestEnum, int> list;

        private enum TestEnum : byte
        {
            One,
            Two,
            Three
        }
    }
}
