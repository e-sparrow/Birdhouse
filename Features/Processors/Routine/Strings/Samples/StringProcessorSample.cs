using System.Collections;
using System.Collections.Generic;
using Birdhouse.Customization.Attributes.ReadOnly;
using TMPro;
using UnityEngine;

namespace Birdhouse.Features.Processors.Routine.Strings.Samples
{
    public class StringProcessorSample
        : MonoBehaviour
    {
        [SerializeField] private string input;
        [SerializeField] private TMP_Text output;

        [ContextMenu("Process input")]
        private void ProcessInput()
        {
            
        }
    }
}
