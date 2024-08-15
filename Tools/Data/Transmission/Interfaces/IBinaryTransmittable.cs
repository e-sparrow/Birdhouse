namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IBinaryTransmittable<T>
        where T : IBinaryTransmittable<T>
    {
        byte[] ToBytes(T from);
        T FromBytes(byte[] from);
    }
}