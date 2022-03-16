using ESparrow.Utils.Generalization.Types.Enums;

namespace ESparrow.Utils.Generalization.Interfaces
{
    public interface IGeneralizationAdapter
    {
        EGeneralizationType GeneralizationType
        {
            get;
        }
    }
}