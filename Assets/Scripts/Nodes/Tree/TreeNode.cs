using System.Collections.Generic;
using ESparrow.Utils.Nodes.Tree;

namespace Nodes.Tree
{
    public class TreeNode<T> : TreeNodeBase<T>
    {
        public TreeNode(T value) : base(value)
        {
        
        }

        public TreeNode(T value, ITreeNode<T> parent) : base(value, parent)
        {
        
        }

        public TreeNode(T value, IList<ITreeNode<T>> children) : base(value, children)
        {
        
        }

        public TreeNode(T value, ITreeNode<T> parent, IList<ITreeNode<T>> children) : base(value, parent, children)
        {
        
        }
    }
}
