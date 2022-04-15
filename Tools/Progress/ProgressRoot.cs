using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Tools.Progress.Interfaces;

namespace ESparrow.Utils.Tools.Progress
{
    public class ProgressRoot : ProgressBase
    {
        public ProgressRoot(IEnumerable<IProgress> progresses) : this(progresses.ToDictionary(value => value, _ => 1f))
        {
            
        }
        
        public ProgressRoot(IDictionary<IProgress, float> progresses)
        {
            _progresses = progresses;
        }

        private readonly IDictionary<IProgress, float> _progresses;

        public override float Current
        {
            get
            {
                var max = _progresses.Sum(value => value.Value);
                var result = _progresses.Sum(GetValue) / max;
                
                return result;

                float GetValue(KeyValuePair<IProgress, float> pair)
                {
                    return pair.Key.Current * pair.Value;
                }
            }
        }
    }
}