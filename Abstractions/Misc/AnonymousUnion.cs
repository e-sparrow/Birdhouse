namespace Birdhouse.Abstractions.Misc
{
    public readonly struct AnonymousUnion<T1, T2>
    {
        public AnonymousUnion(T1 t1, T2 t2)
        {
            _t1 = t1;
            _t2 = t2;
        }

        private readonly T1 _t1;
        private readonly T2 _t2;

        public static implicit operator T1(AnonymousUnion<T1, T2> self)
        {
            return self._t1;
        }
        
        public static implicit operator T2(AnonymousUnion<T1, T2> self)
        {
            return self._t2;
        }
    }
}