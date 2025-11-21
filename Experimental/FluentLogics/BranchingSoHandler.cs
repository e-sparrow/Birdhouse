using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct BranchingSoHandler
    {
        public BranchingSoHandler(BranchingRoot root) => _root = root;

        private readonly BranchingRoot _root;
        
        public ElseIfHandler ElseIf(Func<bool> func) => new ElseIfHandler(_root, func);
        public ElseHandler Else() => new ElseHandler(_root);
    }

    public readonly struct BranchingSoHandler<T>
    {
        public BranchingSoHandler(BranchingRoot<T> root) => _root = root;

        private readonly BranchingRoot<T> _root;
        
        public ElseIfHandler<T> ElseIf(Func<bool> func) => new ElseIfHandler<T>(_root, func);
        public ElseHandler<T> Else() => new ElseHandler<T>(_root);
    }
}