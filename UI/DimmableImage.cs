using UnityEngine;
using UnityEngine.UI;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.UI
{
    [RequireComponent(typeof(Image))]
    [AddComponentMenu("ESparrow/Utils/UI/DimmableImage")]
    public class DimmableImage : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] private float darkenPercent;

        [SerializeField] private Image image;
        [SerializeField] private Image mask;

        public void SetDarkenPercent(float percent)
        {
            darkenPercent = percent;
            UpdateDarken();
        }

        private void UpdateDarken()
        {
            mask.color = Color.black.SetAlpha(darkenPercent);
        }

        private void OnValidate()
        {
            if (image != null && mask != null)
            {
                UpdateDarken();
            }
        }
    }
}
