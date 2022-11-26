using System;
using Birdhouse.Tools.UnityMessages.Enums;

namespace Birdhouse.Tools.UnityMessages.Interfaces
{
    public interface IMonoMessageController
    {
        event Action<EMonoMessage> OnMessageCalled;
        event Action<EMonoEntryMessage> OnEntryMessageCalled; 

        event Action<bool> OnApplicationFocusCalled;
        event Action<bool> OnApplicationPauseCalled;
    }
}