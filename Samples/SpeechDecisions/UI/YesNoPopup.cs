using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Extended.SpeechDecisions.Samples;
using Birdhouse.Features.Decisions;
using Birdhouse.Features.Decisions.Unity;
using Birdhouse.Tools.Inputs.Decisions;
using Birdhouse.Tools.Inputs.Unity;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Ticks.Unity;
using UnityEngine;
using UnityEngine.UI;

public class YesNoPopup 
    : MonoBehaviour
{
    [SerializeField] private GameObject root;

    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    public async Task<bool> WaitForDecision()
    {
        root.SetActive(true);
        
        var listener = UnityInputHelper
            .KeyCodeStateProvider
            .Value
            .AsListener(TenseHelper.InGameTenseProvider.Value, UnityTicksHelper.UpdateProvider);

        var pressureDecider = new PressureDecider<KeyCode, float>(listener, KeyCode.Y, KeyCode.N, KeyCode.Escape, KeyCode.KeypadEnter)
                .Remap(new Dictionary<KeyCode, bool>()
                {
                    { KeyCode.Y, true },
                    { KeyCode.N, false },
                    { KeyCode.KeypadEnter, true },
                    { KeyCode.Escape, false }
                });

        var buttonDecider = new ButtonDecider<bool>(new Dictionary<Button, bool>()
        {
            { yesButton, true },
            { noButton, false }
        });

        var speechDecider = new YesNoSpeechDecider();
        
        var decider = pressureDecider
            .Append(buttonDecider)
            .Append(speechDecider);

        var source = new TaskCompletionSource<bool>();
        
        decider.OnDecide += OnDecide;
        
        return await source.Task;

        void OnDecide(bool result)
        {
            source.SetResult(result);
            root.SetActive(false);
            
            decider.Dispose();
        }
    }
}
