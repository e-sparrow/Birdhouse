namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IDataTransmitter<TData>
    {
        TData GetData();
        void SetData(TData data);
    }
}
