using System;

namespace ESparrow.Utils.Tools.Tense.Controllers
{
    public class TenseController<TTense> : TenseControllerBase<TTense>
    {
        public TenseController(Func<TTense> now)
        {
            _now = now;
        }

        private readonly Func<TTense> _now;

        public override TTense Now()
        {
            return _now.Invoke();
        }
    }
}