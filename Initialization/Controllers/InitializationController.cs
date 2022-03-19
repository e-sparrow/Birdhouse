using System.Threading.Tasks;
using ESparrow.Utils.Initialization.Core.Interfaces;

namespace ESparrow.Utils.Initialization.Controllers
{
    public class InitializationController<TContext> : InitializationControllerBase<TContext>
    {
        public InitializationController(TContext context, IInitializationReporter<TContext> reporter) : base(context, reporter)
        {
            
        }
    }
}