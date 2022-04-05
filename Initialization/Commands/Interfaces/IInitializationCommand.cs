using System.Threading.Tasks;
using ESparrow.Utils.Initialization.Reports.Interfaces;

namespace ESparrow.Utils.Initialization.Commands.Interfaces
{
    public interface IInitializationCommand<in TContext>
    {
        Task Initialize(TContext context);
    }
}