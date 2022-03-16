using UnityEngine;
using TMPro;

namespace ESparrow.Utils.UI
{
    [AddComponentMenu("ESparrow/Utils/UI/FpsCounter")]
    public class FpsCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        [SerializeField] private AnimationCurve curve;
        [SerializeField] private Gradient gradient;

        private void Update()
        {
            int fps = (int) (1f / Time.deltaTime);   

            text.text = $"Fps: {fps}";
            text.color = gradient.Evaluate(curve.Evaluate(fps));
        }
    }
}
