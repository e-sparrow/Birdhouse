using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public sealed class Vector2IntUncertainty
        : IUncertainty<Vector2Int>
    {
        public Vector2IntUncertainty(IUncertainty<int> x, IUncertainty<int> y)
        {
            _x = x;
            _y = y;
        }

        private readonly IUncertainty<int> _x;
        private readonly IUncertainty<int> _y;

        public Vector2Int Perturb() => new Vector2Int(_x.Perturb(), _y.Perturb());
    }
}