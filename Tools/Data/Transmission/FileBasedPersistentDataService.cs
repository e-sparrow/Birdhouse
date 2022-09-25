using System;
using System.Collections.Generic;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission
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