﻿namespace Birdhouse.Tools.Functionality.Interfaces
{
    // TODO: implement
    public interface IPureFunction<in TArgument, out TResult>
    {
        TResult Execute(TArgument argument);
    }
}