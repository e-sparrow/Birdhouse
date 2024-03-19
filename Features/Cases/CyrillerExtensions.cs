using Birdhouse.Common.Exceptions;
using Cyriller.Model;

namespace Birdhouse.Features.Cases
{
    public static class CyrillerExtensions
    {
        public static string As(this string self, CasesEnum @case)
        {
            var value = CyrillerHelper
                .MainNounCollection
                .Value
                .Get(self, out _, out _)
                .Decline();
            
            switch (@case)
            {
                case CasesEnum.Nominative:
                    return value.Nominative;
                case CasesEnum.Genitive:
                    return value.Genitive;
                case CasesEnum.Dative:
                    return value.Dative;
                case CasesEnum.Accusative:
                    return value.Accusative;
                case CasesEnum.Instrumental:
                    return value.Instrumental;
                case CasesEnum.Prepositional:
                    return value.Prepositional;
            }

            throw new WtfException($"Can't decline a word {self} to case {@case.ToString()}");
        }
    }
}