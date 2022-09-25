using System.IO;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Files.Splitting.Interfaces;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Files.Splitting.Examples.Mono
{
    public class MonoFileSplittingTest : MonoBehaviour
    {
        [SerializeField] private string fileName;
        [SerializeField] private string info;

        [SerializeField] private string persistentDataPath;
        
        private readonly IFileSplitter _fileSplitter = new FileSplitter();

        private ISerializationController _serializationController;

        [ContextMenu("Save")]
        private async void Save()
        {
            await _serializationController.Serialize(info);
        }

        [ContextMenu("Load")]
        private async void Load()
        {
            if (_serializationController.IsExist())
            {
                info = await _serializationController.Deserialize<string>();
            }
        }

        [ContextMenu("Split")]
        private void Split()
        {
            _fileSplitter.Split(CreateSettings());
        }
        
        [ContextMenu("Merge")]
        private void Merge()
        {
            _fileSplitter.Merge(CreateSettings());
        }

        private string GetPartName(int index)
        {
            return $"{fileName}_p{index}";
        }

        private IFileSplittingSettings CreateSettings()
        {
            return new FileSplittingSettings(Application.persistentDataPath, fileName, GetPartName, 1);
        }
        
        private void Start()
        {
            persistentDataPath = Application.persistentDataPath;
            
            _serializationController = SerializationHelper.GetDefaultSerializationController(ESerializationMethod.Binary, Directory);
        }

        private string Directory => Path.Combine(Application.persistentDataPath, fileName);
    }
}