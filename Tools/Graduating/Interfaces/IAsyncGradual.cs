using System.Threading.Tasks;

namespace Birdhouse.Tools.Graduating.Interfaces
{
    public interface IAsyncGradual
    {
        Task Graduate(IGradualSettings settings);
    }
}
