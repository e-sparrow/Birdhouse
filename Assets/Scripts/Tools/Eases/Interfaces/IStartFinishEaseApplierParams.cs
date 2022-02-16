using System.Linq.Expressions;

namespace ESparrow.Utils.Tools.Eases.Interfaces
{
    public interface IStartFinishEaseApplierParams<out T>
    {
        T Start
        {
            get;
        }

        T Finish
        {
            get;
        }

        IEase Ease
        {
            get;
        }
    }
}