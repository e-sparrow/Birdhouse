using System.Threading.Tasks;

namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IDataDownloader<out TData>
    {
        TData Download();
    }
    
    public interface IAsyncDataDownloader<TData>
    {
        Task<TData> DownloadAsync();
    }

    public interface IConditionalDataDownloader<TData, out TResult>
    {
        TResult TryDownload(out TData result);
    }

    public interface IConditionalDataDownloader<TData>
        : IConditionalDataDownloader<TData, bool>
    {
        
    }
}