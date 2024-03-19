namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IDataTransmitter<TData>
    {
        bool IsValid();
        
        TData DownloadData();
        void UploadData(TData data);
    }
}
