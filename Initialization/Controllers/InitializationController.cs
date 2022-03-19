using System.Threading.Tasks;
using ESparrow.ZenjectUtils.Initialization.Core.Interfaces;

namespace ESparrow.ZenjectUtils.Initialization.Controllers
{
    public class InitializationController<TContext> : InitializationControllerBase<TContext>
    {
        public InitializationController(TContext context, IInitializationReporter<TContext> reporter) : base(context, reporter)
        {
            
        }
    }
}