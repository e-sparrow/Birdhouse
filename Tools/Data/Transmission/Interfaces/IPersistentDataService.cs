namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IPersistentDataService<in TKey>
    {
        IDataTransmitter<T> GetDataTransmitter<T>(TKey key);
        IAsyncDataTransmitter<T> GetAsyncDataTransmitter<T>(TKey key);
    }
}