using System;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Managers;

namespace ESparrow.Utils.Helpers
{
    /// <summary>
    /// Скрипт-помощник для жестов пальцами на экране.
    /// </summary>
    public class GestureHelper
    {
        public event Action<Vector2> OnTap;
        public event Action<Vector2> OnDoubleTap;

        public event Action<Vector2> OnTouch;
        public event Action<Vector2> OnTouchAndHold;

        public event Action<Vector2, Vector2> OnSwype;
        public event Action<Vector2, Vector2> OnFlick;
        public event Action<Vector2, Vector2> OnDrag;

        public event Action<Vector2, float> OnStretch;

        private const float TapDuration = 0.1f; // Продолжительность нажатия.
        private const float BetweenDoubleTap = 0.1f; // Промежуток между нажатиями для регистрации двойного нажатия.
        private const float TouchDuration = 0.25f; // Продолжительность тача.
        private const float TouchAndHoldDuration = 1f; // Продолжительность тача и удержания.
        private const float MinSwypeLength = 50f; // Минимальная длина свайпа в пикселях.
        private const float MinFlickLength = 150f; // Минимальная длина флика. Так же в пикселях.

        public GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler += Check;
        }

        ~GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler -= Check;
        }

        // TODO:

        private void Check()
        {

        }

        private void CheckTap()
        {

        }
    }
}
