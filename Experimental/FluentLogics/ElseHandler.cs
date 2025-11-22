using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct ElseHandler
    {
        public ElseHandler(BranchingRoot root) => _root = root;
        

        private readonly BranchingRoot _root;

        public void So(Action action) => _root.Execute(action);
    }
    
    public readonly struct ElseHandler<T>
    {
        public ElseHandler(BranchingRoot<T> root) => _root = root;
        

        private readonly BranchingRoot<T> _root;

        public T SoReturn(Func<T> func) => _root.Execute(func);
    }
}