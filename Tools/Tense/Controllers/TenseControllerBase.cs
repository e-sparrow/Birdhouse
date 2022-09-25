using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Tense.Controllers
{
    public abstract class TenseControllerBase<TTense> : ITenseController<TTense>
    {
        public abstract TTense Now();
    }
}