using ESparrow.Utils.Tools.Tense.Controllers.Interfaces;

namespace ESparrow.Utils.Tools.Tense.Controllers
{
    public abstract class TenseControllerBase<TTense> : ITenseController<TTense>
    {
        public abstract TTense Now();
    }
}