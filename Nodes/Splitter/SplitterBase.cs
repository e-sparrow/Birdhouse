using System;
using System.Collections.Generic;
using ESparrow.Utils.Nodes.Splitters.Interfaces;

namespace ESparrow.Utils.Nodes.Splitters
{
    public abstract class SplitterBase<TNode, TId> : ISplitter<TNode, TId>
    {
        private readonly IDictionary<TId, TNode> _nodes = new Dictionary<TId, TNode>();

        protected abstract TId GenerateId(TNode node);

        public void Fire(Action<TId, TNode> action)
        {
            foreach (var node in _nodes)
            {
                action.Invoke(node.Key, node.Value);
            }
        }

        public TId Hook(TNode node)
        {
            var id = GenerateId(node);
            _nodes.Add(id, node);

            return id;
        }

        public TNode Unhook(TId id)
        {
            var node = _nodes[id];
            _nodes.Remove(id);

            return node;
        }
    }
}