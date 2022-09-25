using System.Collections.Generic;
using Birdhouse.Tools.Nodes.Tree.Interfaces;

namespace Birdhouse.Tools.Nodes.Tree
{
    public class TreeNode<T> : TreeNodeBase<T>
    {
        public TreeNode(T value) : base(value)
        {
        
        }

        public TreeNode(T value, ITreeNode<T> parent) : base(value, parent)
        {
        
        }

        public TreeNode(T value, IEnumerable<ITreeNode<T>> children) : base(value, children)
        {
        
        }

        public TreeNode(T value, ITreeNode<T> parent, IEnumerable<ITreeNode<T>> children) : base(value, parent, children)
        {
        
        }
    }
}
