using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission
{
    public class PathPersistentDataService : FileBasedPersistentDataServiceBase<string>
    {
        public PathPersistentDataService(ESerializationMethod method)
        {
            _method = method;
        }

        private readonly ESerializationMethod _method;
        
        protected override ISerializationController CreateController(string key)
        {
            var controller = SerializationHelper.GetDefaultSerializationController(_method, key);
            return controller;
        }
    }
}