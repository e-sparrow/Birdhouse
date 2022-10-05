using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Tense.Controllers
{
    public abstract class TenseProviderBase<TTense> : ITenseProvider<TTense>
    {
        public abstract TTense Now();
    }
}