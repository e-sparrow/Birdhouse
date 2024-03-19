using System.Threading.Tasks;

namespace Birdhouse.Abstractions.Initializables.Interfaces
{
    public interface IAsyncInitializable
    {
        Task Initialize();
    }
}