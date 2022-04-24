using System;
using System.Collections.Generic;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Data.Transmission
{
    public class FileBasedPersistentDataService<TKey> : FileBasedPersistentDataServiceBase<TKey>
    {
        public FileBasedPersistentDataService
            (Func<TKey, ISerializationController> creator) 
            : this(creator, new Dictionary<TKey, ISerializationController>())
        {
            
        }

        public FileBasedPersistentDataService
            (Func<TKey, ISerializationController> creator, IDictionary<TKey, ISerializationController> controllers) 
            : base(controllers)
        {
            _creator = creator;
        }

        private readonly Func<TKey, ISerializationController> _creator;

        protected override ISerializationController CreateController(TKey key)
        {
            return _creator.Invoke(key);
        }
    }
}