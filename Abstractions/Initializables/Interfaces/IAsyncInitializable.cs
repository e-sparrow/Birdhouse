using System.Threading.Tasks;
using Birdhouse.Abstractions.Interfaces;

namespace Birdhouse.Abstractions.Initializables.Interfaces
{
    public interface IAsyncInitializable
    {
        Task Initialize();
    }

    public interface IAsyncInitializable<out TInput>
        : IInitializable<Task, TInput>
    {
        
    }
}