#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tools.Misc
{
    public static class PlayerPrefsTools
    {
        [MenuItem("Birdhouse/Tools/PlayerPrefs/Clear")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
#endif