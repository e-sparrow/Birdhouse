using System.Collections.ObjectModel;

namespace Birdhouse.Mono.UI.Screens.Interfaces
{
    public interface IScreenLayout
    {
        void Focus(IScreen screen);

        void Add(IScreen screen);
        void Remove(IScreen screen);
        
        IScreen Focused
        {
            get;
        }
        
        Collection<IScreen> Screens
        {
            get;
        }
    }
}