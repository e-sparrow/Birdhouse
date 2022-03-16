using System;
using System.Collections.Generic;

namespace ESparrow.Utils.Nodes.Tree
{
    public interface ITreeNode<T>
    {
        void Traverse(Action<ITreeNode<T>> action);
        void TraverseWhile(Action<ITreeNode<T>> action, Predicate<ITreeNode<T>> condition);
        
        IEnumerable<ITreeNode<T>> Flatten();
        
        ITreeNode<T> FindChild(Predicate<ITreeNode<T>> predicate, bool isRecursive);
        
        T Value
        {
            get;
            set;
        }
        
        ITreeNode<T> Parent
        {
            get;
            set;
        }

        IList<ITreeNode<T>> Children
        {
            get;
        }
    }
}
