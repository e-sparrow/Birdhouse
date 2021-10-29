using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Mathematics.Ways.Interfaces
{
    public interface IBrokenLine : IWay
    {
        IEnumerable<Vector3> Points
        {
            get;
        }
    }
}