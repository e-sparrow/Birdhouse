using System.Threading.Tasks;

namespace ESparrow.Utils.Tools.Graduating.Interfaces
{
    public interface IAsyncGradual
    {
        Task Graduate(IGradualSettings settings);
    }
}
