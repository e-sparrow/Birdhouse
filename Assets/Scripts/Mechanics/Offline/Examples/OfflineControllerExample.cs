using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Mechanics.Offline;
using ESparrow.Utils.Serialization;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Mechanics.Offline.Examples
{
    public class OfflineControllerExample : MonoBehaviour
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

            _idleController = new IdleController(1f);
            _offlineController = new OfflineController(_idleController, _serializationController);
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
