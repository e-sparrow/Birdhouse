using System;
using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Tools.Easing.Interfaces;

namespace ESparrow.Utils.Tools.Easing
{
    public abstract class CompositeEaseBase : ICompositeEase
    {
        protected CompositeEaseBase(IEnumerable<IEase> eases)
        {
            _eases = new List<IEase>(eases);
        }

        private List<IEase> _eases;
        
        public float Evaluate(float progress)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(IEase ease, float length)
        {
            throw new System.NotImplementedException();
        }

        public void EnqueueVoid(float length)
        {
            throw new System.NotImplementedException();
        }

        public IEase Dequeue()
        {
            throw new System.NotImplementedException();
        }
    }
}