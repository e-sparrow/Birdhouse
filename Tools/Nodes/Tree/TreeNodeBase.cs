using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Nodes.Tree.Interfaces;

namespace Birdhouse.Tools.Nodes.Tree
{
    public abstract class TreeNodeBase<T> : ITreeNode<T>
    {
        protected TreeNodeBase(T value)
        {
            Value = value;
        }

        protected TreeNodeBase(T value, ITreeNode<T> parent) : this(value)
        {
            Parent = parent;
        }

        protected TreeNodeBase(T value, IEnumerable<ITreeNode<T>> children) : this(value)
        {
            Children = children;
        }

        protected TreeNodeBase(T value, ITreeNode<T> parent, IEnumerable<ITreeNode<T>> children) : this(value, parent)
        {
            Children = children;
        }

        private static IEnumerable<ITreeNode<T>> GetChildren(ITreeNode<T> node)
        {
            return node.Flatten();
        }

        public void Traverse(Action<ITreeNode<T>> action)
        {
            TraverseWhile(action, _ => true);
        } 
        
        public void TraverseWhile(Action<ITreeNode<T>> action, Predicate<ITreeNode<T>> condition)
        {
            if (!condition.Invoke(this)) return;
            
            action.Invoke(this);

            foreach (var child in Children)
            {
                child.TraverseWhile(action, condition);
            }
        }

        public IEnumerable<ITreeNode<T>> Flatten()
        {
            var allTheChildren = Children.SelectMany(GetChildren);
            return this.ConcatTo(allTheChildren);
        }

        public ITreeNode<T> FindChild(Predicate<ITreeNode<T>> predicate, bool isRecursive = false)
        {
            if (!isRecursive)
            {
                if (TryGetMatch(GetChildren(this), out var childrenMatch))
                {
                    return childrenMatch;
                }
            }
            else
            {
                if (TryGetMatch(Flatten(), out var flattenMatch))
                {
                    return flattenMatch;
                }
            }

            return null;

            bool TryGetMatch(IEnumerable<ITreeNode<T>> enumerable, out ITreeNode<T> match)
            {
                match = default;

                if (!enumerable.Any(predicate, out ITreeNode<T> first)) return false;
                
                match = first;
                return true;

            }
        }

        public T Value
        {
            get;
            set;
        }

        public ITreeNode<T> Parent
        {
            get;
            set;
        }

        public IEnumerable<ITreeNode<T>> Children
        {
            get;
        }
    }
}