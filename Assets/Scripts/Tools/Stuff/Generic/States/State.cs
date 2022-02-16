﻿using System;

namespace ESparrow.Utils.Tools.Stuff.Generic.States
{
    public class State<T> : StateBase<T>
    {
        public event Action OnBackFailure = () => { };
        public event Action OnForwardFailure = () => { };

        protected override void OnFailBack()
        {
            OnBackFailure.Invoke();
        }

        protected override void OnFailForward()
        {
            OnForwardFailure.Invoke();
        }
    }
}