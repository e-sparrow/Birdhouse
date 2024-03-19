namespace Birdhouse.Features.Cases.Interfaces
{
    public interface ICaseGetter<out TValue, in TCase>
    {
        TValue GetCase(TCase @case);
    }
}
