namespace ESparrow.Utils.Helpers
{
    public static class UniversalHelper
    {
        public static T Self<T>(T self)
        {
            return self;
        }

        public static object Self(object self)
        {
            return Self<object>(self);
        }
    }
}