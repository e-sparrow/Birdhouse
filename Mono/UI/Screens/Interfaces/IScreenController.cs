using System.Collections.ObjectModel;

namespace Birdhouse.Mono.UI.Screens.Interfaces
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