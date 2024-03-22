using UnityEngine;

namespace Birdhouse.Tools.Easing
{
    public class Ease 
        : EaseBase
    {
        /// <summary>
        /// Creates default linear ease.
        /// </summary>
        public Ease() 
            : base(value => value)
        {
            
        }

        /// <summary>
        /// Creates ease by Func.
        /// </summary>
        /// <param name="func">Ease Func</param>
        public Ease(Easing<float> func) 
            : base(func)
        {
            
        }

        /// <summary>
        /// Creates ease by curve.
        /// </summary>
        /// <param name="curve">Ease curve</param>
        public Ease(AnimationCurve curve) 
            : base(curve.Evaluate)
        {
            
        }

        protected override float Evaluate(Easing<float> easing, float progress)
        {
            var result = easing.Invoke(progress);
            return result;
        }
    }
}
