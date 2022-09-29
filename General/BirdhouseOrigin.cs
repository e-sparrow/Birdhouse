using System;
using System.Threading.Tasks;
using Birdhouse.Education.Patterns.Singleton.Mono;
using Birdhouse.Features.Routines.Interfaces;
using UnityEngine;

namespace Birdhouse.General
{
    public class BirdhouseOrigin : MonoSingleton<BirdhouseOrigin>
    {
        public IRoutineOrigin Routine => RoutineComponent.Instance;

        private void Update()
        {
            Routine.Append(() => Debug.Log("UPDATE 1"));
            Routine.Append(() => Debug.Log("UPDATE 2"));
        }
        
        private void FixedUpdate()
        {
            Routine.Append(() => Debug.Log("FIXED UPDATE"));
        }
        
        private class RoutineComponent : MonoSingleton<RoutineComponent>, IRoutineOrigin
        {
            private readonly FrameAwaiter UpdateAwaiter = new FrameAwaiter();
            private readonly FrameAwaiter FixedUpdateAwaiter = new FrameAwaiter();

            private void Update()
            {
                UpdateAwaiter.Invoke();
            }

            private void FixedUpdate()
            {
                FixedUpdateAwaiter.Invoke();
            }

            public void Append(Action action)
            {
                UpdateAwaiter.OnInvoke += Perform;

                void Perform()
                {
                    UpdateAwaiter.OnInvoke -= Perform;
                    action.Invoke();
                }
            }

            public async Task WaitForFrame()
            {
                var tcs = new TaskCompletionSource<bool>();
                UpdateAwaiter.OnInvoke += Perform;
                
                await tcs.Task;

                void Perform()
                {
                    UpdateAwaiter.OnInvoke -= Perform;
                    tcs.TrySetResult(true);
                }
            }

            private class FrameAwaiter
            {
                public event Action OnInvoke = () => { };

                private TaskCompletionSource<bool> _completionSource = new TaskCompletionSource<bool>();

                public void Invoke()
                {
                    OnInvoke.Invoke();
                    _completionSource.TrySetResult(true);
                    _completionSource = new TaskCompletionSource<bool>();
                }
            }
        }
    }
}