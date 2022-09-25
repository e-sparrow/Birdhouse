﻿using System.Threading.Tasks;

namespace Birdhouse.Tools.Initialization.Commands.Routine
{
    public class TaskInitializationCommand<T> : InitializationCommandBase<T>
    {
        public TaskInitializationCommand(Task task)
        {
            _task = task;
        }

        private readonly Task _task;

        public override async Task Initialize(T context)
        {
            await _task;
        }
    }
}