using System;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Structs
{
    [Serializable]
    public struct CurveVolumeTypePair 
    {
        public AnimationCurve curve;
        public ESoundVolumeType volumeType;
    }
}
