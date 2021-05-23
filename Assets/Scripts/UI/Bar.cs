using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ESparrow.Utils.UI.Enums;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.UI
{
    [AddComponentMenu("ESparrow/Utils/UI/Bar")]
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Image image;

        [SerializeField] private Gradient gradient;

        [SerializeField] private float graduateDuration;

        private float _progress;
        public float Progress => _progress;

        public void SetProgress(float barProgress)
        {
            float tempProgress = _progress;

            StopAllCoroutines();
            StartCoroutine(CoroutinesHelper.Graduate(SetProgress, graduateDuration));

            void SetProgress(float progress)
            {
                float currentProgress = Mathf.Lerp(tempProgress, barProgress, progress);

                image.fillAmount = currentProgress;
                _progress = currentProgress;
            }
        }
    }
}
