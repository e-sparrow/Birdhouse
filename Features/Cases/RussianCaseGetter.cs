using Birdhouse.Features.Cases.Enums;
using Birdhouse.Features.Cases.Interfaces;

namespace Birdhouse.Features.Cases
{
    public class RussianCaseGetter : ICaseGetter<string, ERussianCase>
    {
        public RussianCaseGetter(string source, ICaseStorage<string, ERussianCase> storage, ICaseGetParams defaultParams)
        {
            _source = source;
            _storage = storage;
            _defaultParams = defaultParams;
        }

        private readonly string _source;
        private readonly ICaseStorage<string, ERussianCase> _storage;
        private readonly ICaseGetParams _defaultParams;

        public string GetCase(ERussianCase @case)
        {
            var result = _storage.GetValue(_source, @case, _defaultParams);
            return result;
        }
    }
}