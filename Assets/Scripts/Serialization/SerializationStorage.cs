using System.Collections.Generic;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization
{
    public class SerializationStorage : SerializationStorageBase 
    {
        public SerializationStorage(ISerializationController controller) : base(controller)
        {
            
        }

        public override void Save()
        {
            Controller.Serialize(Dictionary);
        }

        public override void Load()
        {
            Dictionary = Controller.Deserialize<Dictionary<string, object>>();
        }
    }
}