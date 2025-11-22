using System;

namespace Birdhouse.Common.Helpers
{
    public static class BooleanHelper
    {
        private static readonly Random RandomExemplar = new Random();

        public static bool Random() => RandomExemplar.Next() % 2 == 1;
    }
}