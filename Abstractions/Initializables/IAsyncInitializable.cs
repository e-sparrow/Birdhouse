using System.Threading.Tasks;
using Birdhouse.Abstractions.Interfaces;

namespace Birdhouse.Abstractions.Initializables
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