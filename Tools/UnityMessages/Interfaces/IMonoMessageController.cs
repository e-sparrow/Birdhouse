using System;
using Birdhouse.Tools.UnityMessages.Enums;

namespace Birdhouse.Tools.UnityMessages.Interfaces
{
    public interface IMonoMessageController
    {
        event Action<EUnityMessage> OnMessageCalled;
        event Action<EUnityEntryMessage> OnEntryMessageCalled; 

        event Action<bool> OnApplicationFocusCalled;
        event Action<bool> OnApplicationPauseCalled;
    }
}