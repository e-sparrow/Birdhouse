using System;

namespace Birdhouse.Features.FluentLogics
{
    public static class FluentLogicExtensions
    {
        public static SoHandler So(this bool self, Action action)
        {
            var result = new LogicRoot(() => self)
                .So(action);
            
            return result;
        }

        public static SoHandler So(this Func<bool> self, Action action)
        {
            var result = new LogicRoot(self)
                .So(action);
            
            return result;
        }
    }
}