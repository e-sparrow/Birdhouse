using System;

namespace Birdhouse.Tools.Nodes.Splitter.Interfaces
{
    public interface ISplitter<TNode, TId>
    {
        void Fire(Action<TId, TNode> action);
        
        TId Hook(TNode input);
        TNode Unhook(TId channel);
    }

    public interface ISplitter<TNode> : ISplitter<TNode, TNode>
    {
        void Fire(Action<TNode> action);
    }
}