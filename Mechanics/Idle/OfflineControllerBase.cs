using System;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Mechanics.Idle
{
    public abstract class OfflineControllerBase : IOfflineController
    {
        protected OfflineControllerBase(IIdleController idleController)
        {
            _idleController = idleController;
        }

        private readonly IIdleController _idleController;

        protected abstract DateTime GetCurrentTime();

        protected abstract void SetLastVisit(DateTime currentTime);
        protected abstract bool TryGetLastVisit(out DateTime lastVisit);
        
        public void BecomeOffline()
        {
            var currentTime = GetCurrentTime();
            SetLastVisit(GetCurrentTime());
        }

        public void BecomeOnline()
        {
            if (!TryGetLastVisit(out var lastVisit))
            {
                Debug.Log("No info about previous visit");
                return;
            }

            var currentTime = GetCurrentTime();

            var span = currentTime - lastVisit;
            _idleController.IdleFor(span);
        }
    }
}