using System;
using ESparrow.Utils.Data.Interfaces;
using ESparrow.Utils.Data.Transmission;
using ESparrow.Utils.Serialization;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Helpers
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