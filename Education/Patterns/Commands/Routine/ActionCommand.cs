using System;

namespace Birdhouse.Education.Patterns.Commands.Routine
{
    public class ActionCommand : CommandBase<Action>
    {
        public ActionCommand(Action doDelegate, Action undoDelegate) : base(doDelegate, undoDelegate)
        {
            
        }
    }
}
