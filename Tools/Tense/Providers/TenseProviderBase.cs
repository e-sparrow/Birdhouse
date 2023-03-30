using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense.Providers
{
    public abstract class TenseProviderBase<TTense> : ITenseProvider<TTense>
    {
        public abstract TTense Now();
    }
}