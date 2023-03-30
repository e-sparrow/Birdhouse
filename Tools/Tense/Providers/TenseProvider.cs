using System;

namespace Birdhouse.Tools.Tense.Providers
{
    public class TenseProvider<TTense> : TenseProviderBase<TTense>
    {
        public TenseProvider(Func<TTense> now)
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