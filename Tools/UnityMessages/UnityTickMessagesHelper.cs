using System;
using System.Collections.Generic;
using Birdhouse.Tools.UnityMessages.Enums;
using UnityEngine.PlayerLoop;

namespace Birdhouse.Tools.UnityMessages
{
    public class UnityTickMessagesHelper
    {
        private static readonly IDictionary<EUnityTickMessage, Type> UnityTickMessages
            = new Dictionary<EUnityTickMessage, Type>()
            {
                {
                    EUnityTickMessage.EarlyUpdate,
                    typeof(EarlyUpdate)
                },

                {
                    EUnityTickMessage.PreUpdate,
                    typeof(PreUpdate)
                },

                {
                    EUnityTickMessage.Update,
                    typeof(Update)
                },

                {
                    EUnityTickMessage.TimeUpdate,
                    typeof(TimeUpdate)
                },

                {
                    EUnityTickMessage.PreLateUpdate,
                    typeof(PreLateUpdate)
                },

                {
                    EUnityTickMessage.PostLateUpdate,
                    typeof(PostLateUpdate)
                },

                {
                    EUnityTickMessage.FixedUpdate,
                    typeof(FixedUpdate)
                }
            };

        public static Type GetUnityTickMessageType(EUnityTickMessage message)
        {
            var result = UnityTickMessages[message];
            return result;
        }
    }
}