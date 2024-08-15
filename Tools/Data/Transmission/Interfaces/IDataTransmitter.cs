namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IDataTransmitter<TData>
        : IDataUploader<TData>, IDataDownloader<TData>
    {
        bool IsValid();
    }
}
