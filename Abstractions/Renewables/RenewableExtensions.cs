using Birdhouse.Abstractions.Renewables.Interfaces;

namespace Birdhouse.Abstractions.Renewables
{
    public static class RenewableExtensions
    {
        public static T Toggle<T>(this T self) where T : IRenewable
        {
            var target = !self.IsPaused;
            
            self.SetPaused(target);
            return self;
        }
    }
}