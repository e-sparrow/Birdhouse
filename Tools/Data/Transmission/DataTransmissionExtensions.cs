using Birdhouse.Common.Helpers;
using Birdhouse.Common.Reflection.Conversions;
using Birdhouse.Common.Reflection.Conversions.Interfaces;
using Birdhouse.Tools.Data.Transmission.Adapters;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Data.Transmission.Routine;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission
{
    public static class DataTransmissionExtensions
    {
        public static IDataTransmitter<T> AsSync<T>(this IAsyncDataTransmitter<T> self)
        {
            var result = new AsyncDataTransmitterToSyncAdapter<T>(self);
            return result;
        }

        public static IAsyncDataTransmitter<T> AsDataTransmitter<T>(this ISerializationController controller)
        {
            var result = new SerializationControllerToDataTransmitterAdapter<T>(controller);
            return result;
        }

        public static IPersistentDataService<TKey> AsPersistentDataService<TKey>(this ISerializationStorage<TKey> self)
        {
            var result = new StoragePersistentDataService<TKey>(self);
            return result;
        }

        // TODO: Test and add same things to async data transmitter
        public static IDataTransmitter<TTo> Convert<TFrom, TTo>
        (
            this IDataTransmitter<TFrom> self,
            IReversibleSpecificTypedConversion<TFrom, TTo> conversion = null
        )
        {
            conversion ??= ConversionHelper.GetDefaultReversibleConversion<TFrom, TTo>();
            
            var result = new ConvertDataTransmitterAdapter<TFrom, TTo>(self, conversion);
            return result;
        }
        
        
    }
}