using Birdhouse.Tools.Conversion.Interfaces;
using Birdhouse.Tools.Data.Transmission.Interfaces;

namespace Birdhouse.Tools.Data.Transmission.Adapters
{
    public class ConvertDataTransmitterAdapter<TFrom, TTo> : IDataTransmitter<TTo>
    {
        public ConvertDataTransmitterAdapter(IDataTransmitter<TFrom> transmitter, IReversibleSpecificTypedConversion<TFrom, TTo> conversion)
        {
            _transmitter = transmitter;
            _conversion = conversion;
        }

        private readonly IDataTransmitter<TFrom> _transmitter;
        private readonly IReversibleSpecificTypedConversion<TFrom, TTo> _conversion;

        public bool IsValid()
        {
            var result = _transmitter.IsValid();
            return result;
        }

        public TTo GetData()
        {
            var data = _transmitter.GetData();

            var result = _conversion.Convert(data);
            return result;
        }

        public void SetData(TTo data)
        {
            var converted = _conversion.Convert(data);
            _transmitter.SetData(converted);
        }
    }
}