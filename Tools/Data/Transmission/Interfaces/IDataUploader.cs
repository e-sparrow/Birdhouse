using System.Threading.Tasks;

namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IDataUploader<in TData>
    {
        void Upload(TData data);
    }

    public interface IAsyncDataUploader<in TData>
    {
        Task UploadAsync(TData data);
    }

    public interface IConditionalDataUploader<in TData, out TResult>
    {
        TResult TryUpload(TData data);
    }

    public interface IConditionalDataUploader<in TData> 
        : IConditionalDataUploader<TData, bool>
    {
        
    }
}