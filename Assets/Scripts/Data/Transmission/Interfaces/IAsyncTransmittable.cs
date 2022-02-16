using System.Threading.Tasks;

namespace ESparrow.Utils.Data.Interfaces
{
    public interface IAsyncTransmittable<TData>
    {
        Task<TData> GetData();
        Task SetData(TData data);
    }
}