using System.Collections.Generic;
using Birdhouse.Tools.Serialization;
using Birdhouse.Tools.Serialization.Adapters.Formatters;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Default formatter adapters to get it by enum.
        /// </summary>
        private static readonly Dictionary<ESerializationMethod, ISerializationFormatter> Formatters =
            new Dictionary<ESerializationMethod, ISerializationFormatter>()
            {
                {
                    ESerializationMethod.Xml, new XmlFormatterAdapter()
                },

                {
                    ESerializationMethod.Json, new JsonFormatterAdapter()
                },

                {
                    ESerializationMethod.Binary, new BinaryFormatterAdapter()
                }
            };

        /// <summary>
        /// Get default formatter by enum.
        /// </summary>
        /// <param name="method">Enum to get formatter</param>
        /// <returns>Formatter by method type if it's exist</returns>
        public static ISerializationFormatter GetDefaultSerializationFormatter(ESerializationMethod method)
        {
            var result = Formatters[method];
            return result;
        }

        /// <summary>
        /// Get default method by enum.
        /// </summary>
        /// <param name="method">Enum to get method</param>
        /// <returns>Method by method type if it's exist</returns>
        public static ISerializationMethod GetDefaultSerializationMethod(ESerializationMethod method)
        {
            var result = new SerializationMethod(GetDefaultSerializationFormatter(method));
            return result;
        }

        /// <summary>
        /// Get default controller by enum.
        /// </summary>
        /// <param name="method">Enum to get controller</param>
        /// <param name="directory">Directory where to save data</param>
        /// <returns>Controller by method type if it's exist</returns>
        public static ISerializationController GetDefaultSerializationController(ESerializationMethod method, string directory)
        {
            var result = new SerializationController(GetDefaultSerializationMethod(method), directory);
            return result;
        }
        
        /// <summary>
        /// Get default storage by enum.
        /// </summary>
        /// <param name="method">Enum to get storage</param>
        /// <param name="directory">Directory where to save data</param>
        /// <returns>Storage by method type if it's exist</returns>
        public static ISerializationStorage<TKey> GetDefaultSerializationStorage<TKey>(ESerializationMethod method, string directory)
        {
            var result = new SerializationStorage<TKey>(GetDefaultSerializationController(method, directory));
            return result;
        }
    }
}