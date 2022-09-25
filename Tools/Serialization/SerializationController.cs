using System.IO;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public class SerializationController : SerializationControllerBase
    {
        public SerializationController(ISerializationMethod method, string directory) : base(method)
        {
            _directory = directory;
        }

        private readonly string _directory;

        protected override Stream GetStreamToWrite()
        {
            var stream = new FileStream(_directory, FileMode.OpenOrCreate, FileAccess.Write);
            return stream;
        }

        protected override Stream GetStreamToRead()
        {
            var stream = new FileStream(_directory, FileMode.OpenOrCreate, FileAccess.Read);
            return stream;
        }
    }
}