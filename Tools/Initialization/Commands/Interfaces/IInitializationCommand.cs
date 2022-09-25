using System.Threading.Tasks;

namespace Birdhouse.Tools.Initialization.Commands.Interfaces
{
    public interface IInitializationCommand<in TContext>
    {
        Task Initialize(TContext context);
    }
}