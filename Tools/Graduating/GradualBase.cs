using System.Collections;
using ESparrow.Utils.Tools.Graduating.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Graduating
{
    public abstract class GradualBase : IGradual
    {
        protected abstract YieldInstruction SkipFrame();
        
        public IEnumerator Graduate(IGradualSettings settings)
        {
            for (float time = 0f; time < settings.Duration.TotalSeconds; time += Time.deltaTime)
            {
                var progress = settings.Ease.Evaluate(time / (float) settings.Duration.TotalSeconds);
                settings.Action.Invoke(progress);

                yield return SkipFrame();
            }
        }
    }
}
