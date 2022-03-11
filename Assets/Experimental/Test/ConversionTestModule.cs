using System;
using ESparrow.Utils.Helpers;
using UnityEngine;

namespace ESparrow.Utils.Experimental
{
    [Serializable]
    public class ConversionTestModule : TestModuleBase
    {
        public override void Test()
        {
            var vector2 = new Vector2();
            ConversionHelper.TryConvert(vector2, out Vector3 vector3);
        }
    }
}
