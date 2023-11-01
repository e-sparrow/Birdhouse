using System;
using Birdhouse.Features.LogicSlicing.Interfaces;
using Birdhouse.Tools.UnityMessages;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Birdhouse.Features.LogicSlicing
{
    public static class UnityLogicSlicingHelper
    {
        public static readonly Lazy<IOrderedLogicSlicer> UpdateSlicer =
            new Lazy<IOrderedLogicSlicer>(CreateUpdateSlicer);
        
        public static readonly Lazy<IOrderedLogicSlicer> LateUpdateSlicer =
            new Lazy<IOrderedLogicSlicer>(CreateLateUpdateSlicer);
            
        public static readonly Lazy<IOrderedLogicSlicer> FixedUpdateSlicer =
            new Lazy<IOrderedLogicSlicer>(CreateFixedUpdateSlicer);

        private static IOrderedLogicSlicer CreateUpdateSlicer()
        {
            var result = CreatePlayerLoopSlicer<Update>();
            return result;
        }

        private static IOrderedLogicSlicer CreateLateUpdateSlicer()
        {
            var result = CreatePlayerLoopSlicer<PostLateUpdate>();
            return result;
        }

        private static IOrderedLogicSlicer CreateFixedUpdateSlicer()
        {
            var result = CreatePlayerLoopSlicer<FixedUpdate>();
            return result;
        }

        private static IOrderedLogicSlicer CreatePlayerLoopSlicer<T>()
        {
            var result = new OrderedLogicSlicer();
            
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find<T>();
            system.updateDelegate += Invoke;
            PlayerLoop.SetPlayerLoop(loop);
            
            return result;

            void Invoke()
            {
                result.Trigger();
            }
        }
    }
}