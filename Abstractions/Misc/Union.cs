namespace Birdhouse.Abstractions.Misc
{
    public sealed class UnionDummy<TSelf, T1, T2>
        : IUnion<UnionDummy<TSelf, T1, T2>, T1, T2> 
        where TSelf : T1, T2
    {
        public UnionDummy(TSelf value)
        {
            _value = value;
        }

        private readonly TSelf _value;

        public static implicit operator T1(UnionDummy<TSelf, T1, T2> self)
        {
            return self._value;
        }

        public static implicit operator T2(UnionDummy<TSelf, T1, T2> self)
        {
            return self._value;
        }
    }
    
    public sealed class UnionDummy<TSelf, T1, T2, T3>
        : IUnion<TSelf, T1, T2, T3> 
        where TSelf : IUnion<TSelf, T1, T2, T3>, T1, T2, T3
    {
        public UnionDummy(TSelf value)
        {
            
        }
    }
    
    public sealed class UnionDummy<TSelf, T1, T2, T3, T4>
        : IUnion<TSelf, T1, T2, T3, T4> 
        where TSelf : IUnion<TSelf, T1, T2, T3, T4>, T1, T2, T3, T4
    {
        public UnionDummy(TSelf value)
        {
            
        }
    }
    
    public sealed class UnionDummy<TSelf, T1, T2, T3, T4, T5>
        : IUnion<TSelf, T1, T2, T3, T4, T5> 
        where TSelf : IUnion<TSelf, T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5
    {
        public UnionDummy(TSelf value)
        {
            
        }
    }
}