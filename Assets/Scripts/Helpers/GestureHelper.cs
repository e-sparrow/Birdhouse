using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Managers;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Helpers
{
    /// <summary>
    /// Скрипт-помощник для жестов пальцами на экране.
    /// </summary>
    public class GestureHelper
    {
        public delegate void Tap(Vector2 position);
        public delegate void DoubleTap(Vector2 position);
        public delegate void Touch(Vector2 position);
        public delegate void TouchAndHold(Vector2 position);

        public delegate void Swype(Vector2 from, Vector2 to);
        public delegate void Flick(Vector2 from, Vector2 to);

        public event Action<Vector2> OnTap;
        public event Action<Vector2> OnDoubleTap;

        public event Action<Vector2> OnTouch;
        public event Action<Vector2> OnTouchAndHold;

        public event Action<Vector2, Vector2> OnSwype;
        public event Action<Vector2, Vector2> OnFlick;

        public event Action<Vector2> OnDrag;
        public event Action<Vector2, float> OnStretch;

        private const float MaxTouchesMagnitude = 5f; // Максимальное расстояние для того, чтобы зарегистрировался тач.
        private const float TapDuration = 0.1f; // Продолжительность нажатия.
        private const float BetweenDoubleTap = 0.1f; // Промежуток между нажатиями для регистрации двойного нажатия.
        private const float TouchDuration = 0.25f; // Продолжительность тача.
        private const float TouchAndHoldDuration = 1f; // Продолжительность тача и удержания.

        private const float MaxSwypeDuration = 0.75f; // Максимальное время свайпа. Если 
        private const float MaxFlickDuration = 1.5f; // Максимальное время флика.
        private const float MinSwypeLength = 25f; // Минимальная длина свайпа в пикселях.
        private const float MinFlickLength = 100f; // Минимальная длина флика. Так же в пикселях.

        // private readonly List<GestureListenerBase> _listeners = new List<GestureListenerBase>();

        public GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler += Check;
        }

        ~GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler -= Check;
        }

        private void Check()
        {
            // _listeners.ForEach(value => value.Check());
        }

        private abstract class GestureListenerGeneric<T>
        {
            public abstract void Check(out T result);
        }

        private abstract class GestureListener
        {
            public GestureListener()
            {

            }

            public abstract void Check();
        }

        private class DragListener : GestureListener
        {
            public override void Check()
            {
                throw new NotImplementedException();
            }
        }

        private class StretchListener : GestureListener
        {
            public event Action<Vector2, float> OnStretch;

            private float _deltaMagnitude;
            private bool _stretching = false;

            public override void Check()
            {
                if (Input.touches.Length > 1)
                {
                    var averagePosition = Input.touches.Select(value => value.position).Sum() / Input.touchCount;
                    var magnitude = (Input.GetTouch(0).position - averagePosition).magnitude;

                    if (!_stretching)
                    {
                        _stretching = true;
                        _deltaMagnitude = magnitude;
                        return;
                    }

                    OnStretch.Invoke(averagePosition, magnitude - _deltaMagnitude);

                    _deltaMagnitude = magnitude;
                }
                else
                {
                    _stretching = false;
                }
            }
        }
    }
}
