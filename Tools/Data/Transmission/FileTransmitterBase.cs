using System.IO;
using System.Threading.Tasks;
using Birdhouse.Tools.Data.Transmission.Interfaces;

namespace Birdhouse.Tools.Data.Transmission
{
    public abstract class FileTransmitterBase<T>
        : IAsyncDataTransmitter<T>
    {
        protected FileTransmitterBase(string path)
        {
            _path = path;
        }

        private readonly string _path;

        protected abstract byte[] ToBytes(T value);
        protected abstract T FromBytes(byte[] value);
        
        public bool IsValid()
        {
            var result = File.Exists(_path);
            return result;
        }

        public async Task<T> GetData()
        {
            var binary = await File.ReadAllBytesAsync(_path);
           
            var result = FromBytes(binary);
            return result;
        }

        public Task SetData(T data)
        {
            var binary = ToBytes(data);

            if (IsValid())
            {
                File.Delete(_path);
            }

            return File.WriteAllBytesAsync(_path, binary);
        }
    }
}