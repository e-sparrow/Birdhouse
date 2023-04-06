using Birdhouse.Common.Files;
using Birdhouse.Common.Singleton;
using Birdhouse.Common.Singleton.Scriptable;
using Birdhouse.Common.Singleton.Scriptable.Attributes;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tests.Editor.Settings
{
    [CreateAssetMenu(menuName = "Birdhouse/Tests/Settings/Editor", fileName = "EditorTestsSettings")]
    public class EditorTestsSettings : ScriptableSingletonBase<EditorTestsSettings>
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