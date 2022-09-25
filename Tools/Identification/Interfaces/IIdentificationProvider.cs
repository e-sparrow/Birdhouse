namespace Birdhouse.Tools.Identification.Interfaces
{
    public interface IIdentificationProvider<in T>
    {
        public bool CheckIdentity(T left, T right);
    }
}