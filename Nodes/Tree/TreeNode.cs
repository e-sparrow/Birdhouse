using System.Collections.Generic;
using ESparrow.Utils.Nodes.Tree;

namespace ESparrow.Utils.Nodes.Tree
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
