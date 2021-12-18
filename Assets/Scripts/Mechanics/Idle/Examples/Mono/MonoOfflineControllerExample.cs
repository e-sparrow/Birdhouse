using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Mechanics.Idle;
using ESparrow.Utils.Serialization;
using ESparrow.Utils.Serialization.Enums;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using Global;
using Global.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Mechanics.Idle.Examples.Mono
{
    public class MonoOfflineControllerExample : MonoBehaviour
    {
        [SerializeField] private string fileName;
        
        private ISerializationController _serializationController;

        private ITimeManager _timeManager;
        private IIdleController _idleController;
        private IOfflineController _offlineController;

        private void Awake()
        {
            var directory = Application.persistentDataPath + "/" + fileName;
            var method = SerializationHelper.GetDefaultSerializationMethod(ESerializationMethod.Binary);

            _serializationController = new SerializationController(method, directory);

            _timeManager = new TimeManager();
            _idleController = new IdleController();
            _offlineController = new OfflineController(_timeManager, _idleController, _serializationController);
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
