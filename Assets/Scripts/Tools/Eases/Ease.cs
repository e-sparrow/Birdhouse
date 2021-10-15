using System;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases
{
    public class Ease : EaseBase
    {
        /// <summary>
        /// Creates default linear ease.
        /// </summary>
        public Ease()
        {
            
        }

        /// <summary>
        /// Creates ease by Func.
        /// </summary>
        /// <param name="func">Ease Func</param>
        public Ease(Func<float, float> func) : base(func)
        {
            
        }

        /// <summary>
        /// Creates ease by curve.
        /// </summary>
        /// <param name="curve">Ease curve</param>
        public Ease(AnimationCurve curve) : base(curve.Evaluate)
        {
            
        }

        public override float Evaluate(float progress)
        {
            return Func.Invoke(progress);
        }
    }
}
