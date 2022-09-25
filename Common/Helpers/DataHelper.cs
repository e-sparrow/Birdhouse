using System;
using Birdhouse.Tools.Data.Transmission;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public static class DataHelper
    {
        public static class Transmission
        {
            public static IPersistentDataService<TKey> CreateFileBasedPersistentDataService<TKey>
                (ISerializationMethod method, Func<TKey, string> fileNameSelector)
            {
                return new FileBasedPersistentDataService<TKey>(CreateController);

                ISerializationController CreateController(TKey name)
                {
                    var realName = fileNameSelector.Invoke(name);
                    var controller = new SerializationController(method, realName);

                    return controller;
                }
            }
        }
    }
}