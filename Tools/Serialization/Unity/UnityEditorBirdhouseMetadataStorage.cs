#if UNITY_EDITOR
using System;
using System.IO;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Serialization.Unity
{
    internal static class UnityEditorBirdhouseMetadataStorage
    {
        private const ESerializationMethod SerializationMethod = ESerializationMethod.Binary;
        private const string RelativePath = @"Assets\Birdhouse\Meta.data";
        
        private static readonly string SerializationPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), RelativePath);
        
        private static readonly Lazy<ISerializationStorage<string>> LazySelf =
            new Lazy<ISerializationStorage<string>>(CreateDefaultStorage);

        public static ISerializationStorage<string> Self => LazySelf.Value;
        
        private static ISerializationStorage<string> CreateDefaultStorage()
        {
            var result = SerializationHelper.GetDefaultSerializationStorage<string>
                (SerializationMethod, SerializationPath);

            result.Load();

            Application.quitting += Dispose;
            
            return result;
        }

        private static void Dispose()
        {
            Application.quitting -= Dispose;
            
            Self.Save();
        }
    }
}
#endif
