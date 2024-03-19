using System;
using Cyriller;

namespace Birdhouse.Features.Cases
{
    public static class CyrillerHelper
    {
        public static Lazy<CyrNounCollection> MainNounCollection
            = new Lazy<CyrNounCollection>(() => new CyrNounCollection());
    }
}