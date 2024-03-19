namespace Birdhouse.Features.Cases.Interfaces
{
    public interface ICaseStorage<TValue, in TCase>
    {
        TValue GetValue(TValue source, TCase @case, ICaseGetParams @params);
    }
}