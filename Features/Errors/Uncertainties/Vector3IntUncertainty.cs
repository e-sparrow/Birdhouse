using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public sealed class Vector3IntUncertainty
        : IUncertainty<Vector3Int>
    {
        public Vector3IntUncertainty(IUncertainty<int> x, IUncertainty<int> y, IUncertainty<int> z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        private readonly IUncertainty<int> _x;
        private readonly IUncertainty<int> _y;
        private readonly IUncertainty<int> _z;

        public Vector3Int Perturb() => new Vector3Int(_x.Perturb(), _y.Perturb(), _z.Perturb());
    }
}