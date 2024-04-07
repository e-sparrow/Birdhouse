using Birdhouse.Abstractions.Renewables;

namespace Birdhouse.Abstractions.Renewables
{
    public static class RenewableExtensions
    {
        public static T Toggle<T>(this T self) where T : IRenewable
        {
            self.IsPaused = !self.IsPaused;
            return self;
        }
    }
}