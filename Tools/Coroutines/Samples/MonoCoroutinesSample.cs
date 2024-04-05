using System.Collections;
using System.Collections.Generic;
using Birdhouse.Extended.LogicSlicing.Unity;
using Birdhouse.Features.LogicSlicing.Samples;
using Birdhouse.Features.LogicSlicing.Unity;
using Birdhouse.Tools.Coroutines.Instructions;
using Birdhouse.Tools.Coroutines.Interfaces;
using Birdhouse.Tools.Coroutines.Unity;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Birdhouse.Tools.Coroutines.Samples
{
    public class MonoCoroutinesSample
        : MonoBehaviour
    {
        [ContextMenu("Start as usual")]
        private void StartAsUsual()
        {
            StartCoroutine(SampleCoroutine()
                .Measure(stopwatch => Debug.Log($"Coroutine elapsed {stopwatch.Elapsed.Seconds} seconds")));
        }

        [ContextMenu("Start alternative")]
        private void StartAlternative()
        {
            UnityCoroutineHelper
                .CoroutineStarter
                .Start(SampleCoroutine()
                    .Measure(stopwatch => Debug.Log($"Coroutine elapsed {stopwatch.Elapsed.Seconds} seconds")));
        }

        [ContextMenu("Start sliced")]
        private void StartSliced()
        {
            UnityLogicSlicingHelper
                .SmartLogicSlicers[typeof(Update)]
                .GetOrCreate(5)
                .GetOrRegisterGroup(typeof(SlicedCoroutineSample).GetHashCode())
                .StartCoroutine(SampleCoroutine()
                    .Measure(stopwatch => Debug.Log($"Coroutine elapsed {stopwatch.Elapsed.Seconds} seconds")));
        }

        [ContextMenu("Start birdhouse coroutine")]
        private void StartBirdhouse()
        {
            CoroutinesHelper
                .CoroutineStarter
                .Start(SampleBirdhouseCoroutine()
                    .Measure(stopwatch => Debug.Log($"Coroutine elapsed {stopwatch.Elapsed.Seconds} seconds")));
        }

        private IEnumerator SampleCoroutine()
        {
            for (var i = 0; i < 1000; i++)
            {
                yield return null;
                Debug.Log($"SampleCoroutine's {i} iteration...");
            }
        }

        private IEnumerator<ICoroutineInstruction> SampleBirdhouseCoroutine()
        {
            for (var i = 0; i < 1000; i++)
            {
                yield return new WaitForFrameInstruction();
                Debug.Log($"SampleBirdhouseCoroutine's {i} iteration...");
            }
        }
    }
}