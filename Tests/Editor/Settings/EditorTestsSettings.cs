using Birdhouse.Common.Files;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tests.Editor.Settings
{
    [CreateAssetMenu(menuName = "Birdhouse/Tests/Settings/Editor", fileName = "EditorTestsSettings")]
    public class EditorTestsSettings : ScriptableSingleton<EditorTestsSettings>
    {
        [field: SerializeField]
        public string RootDirectory
        {
            get;
            private set;
        }
        
        [field: SerializeField]
        public DataTransmissionTestsSettings DataTransmissionTestsSettings
        {
            get;
            private set;
        }

        [ContextMenu("Clear persistent data")]
        public void ClearPersistentData()
        {
            FilesHelper.ClearDirectory(RootDirectory);
        }
    }
}