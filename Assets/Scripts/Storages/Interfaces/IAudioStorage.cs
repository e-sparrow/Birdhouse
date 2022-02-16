using UnityEngine;

namespace ESparrow.Utils.Storages.Interfaces
{
    public interface IAudioStorage<in TKey> : IKeyValueStorage<TKey, AudioClip>
    {
        
    }
}
