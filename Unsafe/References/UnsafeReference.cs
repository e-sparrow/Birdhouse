using ESparrow.Utils.Generic.References.Interfaces;

namespace ESparrow.Utils.Unsafe.References
{
    public class UnsafeReference<T> : IReference<T> where T : unmanaged
    {
        public unsafe UnsafeReference(T* pointer)
        {
            _pointer = pointer;
        }
        
        private readonly unsafe T* _pointer;

        public unsafe T Value
        {
            get => *_pointer;
            set => *_pointer = value;
        }
    }
}