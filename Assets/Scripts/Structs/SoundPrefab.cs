using System;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Structs
{
    /// <summary>
    /// Структура для поиска префаба по типу.
    /// </summary>
    [Serializable]
    public struct SoundPrefab
    {
        public GameObject prefab;
        public ESoundVolumeType type;
    }
}
