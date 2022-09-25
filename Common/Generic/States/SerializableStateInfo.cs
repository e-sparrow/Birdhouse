using System;
using System.Collections.Generic;
using Birdhouse.Common.Generic.States.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Generic.States
{
    [Serializable]
    public struct SerializableStateInfo<T> : IStateInfo<T>
    {
        public SerializableStateInfo(T value, IEnumerable<T> undoStack, IEnumerable<T> redoStack)
        {
            this.value = value;
            
            this.undoStack = new List<T>(undoStack);
            this.redoStack = new List<T>(redoStack);
        }

        [SerializeField] private T value;
        
        [SerializeField] private List<T> undoStack;
        [SerializeField] private List<T> redoStack;

        public T Value => value;

        public IEnumerable<T> UndoStack => undoStack;
        public IEnumerable<T> RedoStack => redoStack;
    }
}
