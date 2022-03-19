using System.Threading.Tasks;
using ESparrow.ZenjectUtils.Initialization.Core.Interfaces;

namespace ESparrow.ZenjectUtils.Initialization.Commands.Interfaces
{
    public interface IInitializationCommand<in TContext>
    {
        Task Initialize(TContext context);
    }
}