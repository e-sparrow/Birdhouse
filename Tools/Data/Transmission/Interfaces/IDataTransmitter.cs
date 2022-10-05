namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IDataTransmitter<TData>
    {
        bool IsValid();
        
        TData GetData();
        void SetData(TData data);
    }
}
