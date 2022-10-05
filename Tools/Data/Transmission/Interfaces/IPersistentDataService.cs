namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IPersistentDataService<in TKey>
    {
        IAsyncDataTransmitter<T> GetDataTransmitter<T>(TKey key);
    }
}