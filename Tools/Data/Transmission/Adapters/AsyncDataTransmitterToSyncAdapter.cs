using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Data.Transmission.Interfaces;

namespace Birdhouse.Tools.Data.Transmission.Adapters
{
    public class AsyncDataTransmitterToSyncAdapter<T> : IDataTransmitter<T>
    {
        public AsyncDataTransmitterToSyncAdapter(IAsyncDataTransmitter<T> dataTransmitter)
        {
            _dataTransmitter = dataTransmitter;
        }

        private readonly IAsyncDataTransmitter<T> _dataTransmitter;

        public bool IsValid()
        {
            var result = _dataTransmitter.IsValid();
            return result;
        }

        public T DownloadData()
        {
            var result = _dataTransmitter
                .GetData()
                .Sync();
            
            return result;
        }

        public void UploadData(T data)
        {
            _dataTransmitter
                .SetData(data)
                .Sync();
        }
    }
}