using System;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Mechanics.Offline
{
    public abstract class OfflineControllerBase : IOfflineController
    {
        protected OfflineControllerBase(IIdleController idleController, ISerializationController serializationController)
        {
            _idleController = idleController;
            _serializationController = serializationController;
        }

        private readonly IIdleController _idleController;
        private readonly ISerializationController _serializationController;

        protected abstract DateTime GetCurrentTime();
        
        public void BecomeOffline()
        {
            var currentTime = GetCurrentTime();
            _serializationController.Serialize(currentTime);
        }

        public void BecomeOnline()
        {
            if (!_serializationController.TryDeserialize<DateTime>(out var tempTime))
            {
                Debug.Log("No info about previous visit");
                return;
            }
            
            var currentTime = GetCurrentTime();

            var span = currentTime - tempTime;
            _idleController.IdleFor(span);
        }
    }
}