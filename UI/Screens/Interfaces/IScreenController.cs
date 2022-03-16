using System.Collections.ObjectModel;

namespace ESparrow.Utils.UI.Screens.Interfaces
{
    public interface IScreenController
    {
        void Open(IScreen screen);
        void Close(IScreen screen);

        void Back(IScreen screen);

        Collection<IScreenLayout> Layouts
        {
            get;
        }
    }
}