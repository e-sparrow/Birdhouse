using UnityEngine;

namespace ESparrow.Utils.Storages.Scriptable
{
    [CreateAssetMenu(fileName = "Storages/Scriptable/AudioStorage", menuName = "ScriptableAudioStorage", order = 0)]
    public class ScriptableAudioStorage : ScriptableStorageBase<string, AudioClip>
    {
        protected override bool IsFit(string key, SerializablePair pair)
        {
            return pair.key == key;
        }
    }
}
