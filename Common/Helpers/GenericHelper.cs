﻿namespace Birdhouse.Common.Helpers
{
    public static class GenericHelper<T>
    {
        public static T Self(T self)
        {
            return UniversalHelper.Self(self);
        }
    }
}