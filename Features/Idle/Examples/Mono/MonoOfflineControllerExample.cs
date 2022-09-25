using Birdhouse.Common.Helpers;
using Birdhouse.Mechanics.Idle.Interfaces;
using Birdhouse.Tools.Serialization;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;
using UnityEngine;

namespace Birdhouse.Mechanics.Idle.Examples.Mono
{
    public class MonoOfflineControllerExample : MonoBehaviour
    {
        [SerializeField] private string fileName;
        
        private ISerializationController _serializationController;

        private IIdleController _idleController;
        private IOfflineController _offlineController;

        private void Awake()
        {
            var directory = Application.persistentDataPath + "/" + fileName;
            var method = SerializationHelper.GetDefaultSerializationMethod(ESerializationMethod.Binary);

            _serializationController = new SerializationController(method, directory);

            _idleController = new IdleController();
            _offlineController = new OfflineController(TenseHelper.Controllers.NowTenseController, _idleController);  
        }

        private void Start()
        {
            _offlineController.BecomeOnline();
        }

        private void OnApplicationQuit()
        {
            _offlineController.BecomeOffline();
        }
    }
}
