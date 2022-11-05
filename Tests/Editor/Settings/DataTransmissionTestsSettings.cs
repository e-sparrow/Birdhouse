using System;
using UnityEngine;

namespace Birdhouse.Tests.Editor.Settings
{
    [Serializable]
    public class DataTransmissionTestsSettings
    {
        [field: SerializeField]
        public string TestPlayerPrefsDataTransmitterKey
        {
            get;
            private set;
        } = "Birdhouse/Tests/TestKey";

        [field: SerializeField]
        public string TestPlayerPrefsDataTransmitterValue
        {
            get;
            private set;
        } = "Test PlayerPrefs value";

        [field: SerializeField]
        public string SerializationStorageFilePath
        {
            get;
            private set;
        } = "Birdhouse/Tests/SerializationStorageTest.data";
    }
}