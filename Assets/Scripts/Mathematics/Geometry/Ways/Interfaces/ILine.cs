using UnityEngine;

namespace ESparrow.Utils.Mathematics.Ways.Interfaces
{
    public interface ILine : IWay
    {
        Vector3 Delta
        {
            get;
        }

        float Length
        {
            get;
        }
    }
}