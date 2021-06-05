using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demos.Patterns.CommandPattern
{
    public class MathBoxesStack : MonoBehaviour
    {
        [SerializeField] private Transform content;

        private readonly Stack<MathCommandBox> _stack = new Stack<MathCommandBox>();

        public void Add(MathCommandBox box)
        {
            box.transform.SetParent(content);
            _stack.Push(box);
        }

        public MathCommandBox Pop()
        {
            if (_stack.Count != 0)
            {
                return _stack.Pop();
            }

            return null;
        }

        public void Clear()
        {
            foreach (var box in _stack)
            {
                Destroy(box.gameObject);
            }

            _stack.Clear();
        }
    }
}
