namespace ESparrow.Utils.Data.Interfaces
{
    public interface ITransmittable<TData>
    {
        TData GetData();
        void SetData(TData data);
    }
}
