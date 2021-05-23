using UnityEngine;
using ESparrow.Utils.Helpers;
using TMPro;

namespace ESparrow.Utils.UI
{
    [AddComponentMenu("ESparrow/Utils/UI/Hint")]
    public class Hint : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Show(string text, float duration)
        {
            this.text.text = text;
            float alpha = this.text.alpha;

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                this.text.alpha = Mathf.Lerp(alpha, 1f, progress);
            }
        }

        public void ShowFor(string text, float duration)
        {
            this.text.text = text;
            float alpha = 1f;

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                this.text.alpha = Mathf.Lerp(alpha, 0f, progress);
            }
        }

        public void Hide(float duration)
        {
            float alpha = text.alpha;

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                text.alpha = Mathf.Lerp(alpha, 0f, progress);
            }
        }
    }
}
