namespace ESparrow.Utils.Data.Interfaces
{
    public interface IDataTransmitter<TData>
    {
        TData GetData();
        void SetData(TData data);
    }
}
