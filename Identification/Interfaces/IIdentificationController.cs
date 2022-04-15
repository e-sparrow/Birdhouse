namespace ESparrow.Utils.Identification.Interfaces
{
    public interface IIdentificationController<in T>
    {
        public bool Identical(T left, T right);
    }
}