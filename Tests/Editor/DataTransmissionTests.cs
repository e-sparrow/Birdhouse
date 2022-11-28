﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using Birdhouse.Tests.Editor.Settings;
using Birdhouse.Tools.Data.Transmission;
using Birdhouse.Tools.Data.Transmission.Routine;
using Birdhouse.Tools.Serialization;
using Birdhouse.Tools.Serialization.Enums;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class DataTransmissionTests
    {
        [Test]
        public void TestPlayerPrefsDataTransmitter()
        {
            while (true)
            {
                Thread.Sleep(100);
                var settings = EditorTestsSettings.instance.DataTransmissionTestsSettings;
                var key = settings.TestPlayerPrefsDataTransmitterKey;
                var data = settings.TestPlayerPrefsDataTransmitterValue;

                var transmitter = new PlayerPrefsStringDataTransmitter(key);
                if (transmitter.IsValid())
                {
                    var value = transmitter.GetData();

                    Debug.Log($"PlayerPrefs data transmitter contains message: {value.WithColor(Color.blue)}");
                    var isCorrect = value == data;
                    
                    Assert.IsTrue(isCorrect);
                }
                else
                {
                    Debug.Log($"PlayerPrefs data transmitter have no value. Setting it to default...");
                    transmitter.SetData(data);

                    Debug.Log($"Trying again...");
                    continue;
                }

                break;
            }
        }

        [Test]
        public void TestSerializationStorageDataTransmitter()
        {
            Thread.Sleep(100);
            
            EnumsHelper<ESerializationMethod>
                .GetValues()
                .Without(ESerializationMethod.Xml, ESerializationMethod.Custom)
                .Foreach(Test);

            void Test(ESerializationMethod method)
            {
                var root = EditorTestsSettings.instance.RootDirectory;
                
                var settings = EditorTestsSettings.instance.DataTransmissionTestsSettings;
                var name = string.Format(root, settings.SerializationStorageFilePath, method);
                var path = Path.Combine(Application.persistentDataPath, name);
                
                var storage = SerializationHelper.GetDefaultSerializationStorage<string>(method, path);
                var service = storage.AsPersistentDataService();

                while (true)
                {
                    var key = settings.TestPlayerPrefsDataTransmitterKey;
                    var transmitter = service.GetDataTransmitter<string>(key).AsSync();

                    var isValid = transmitter.IsValid();
                    if (isValid)
                    {
                        var value = transmitter.GetData();
                        Debug.Log($"Value of transmitter is: {value}");
                    }
                    else
                    {
                        var value = settings.TestPlayerPrefsDataTransmitterValue;
                        transmitter.SetData(value);
                        Debug.Log($"Can't find value of transmitter. Settings it to default...");
                        
                        continue;
                    }

                    break;
                }
            }
        }
    }
}