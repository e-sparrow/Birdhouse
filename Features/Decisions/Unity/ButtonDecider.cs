using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Decisions.Interfaces;
using UnityEngine.UI;

namespace Birdhouse.Features.Decisions.Unity
{
    public class ButtonDecider<TValue>
        : IDecider<TValue>
    {
        public ButtonDecider(IDictionary<Button, TValue> dictionary)
        {
            _dictionary = dictionary;

            foreach (var (button, value) in dictionary)
            {
                button.AddDisposableListener(Decide);

                void Decide()
                {
                    OnDecide.Invoke(value);
                }
            }
        }

        public event Action<TValue> OnDecide = _ => { };

        private readonly IDictionary<Button, TValue> _dictionary;

        public void Dispose()
        {
            _dictionary.Clear();
        }
    }
}