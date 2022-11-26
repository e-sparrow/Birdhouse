using Birdhouse.Abstractions.Entries.Interfaces;

namespace Birdhouse.Abstractions.Entries
{
    public abstract class ScriptableEntryBase : ObjectEntryBase, IEntry
    {
        public void Enter()
        {
            throw new System.NotImplementedException();
        }
    }
}