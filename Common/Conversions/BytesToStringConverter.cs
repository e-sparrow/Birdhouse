using System;
using Birdhouse.Common.Conversions.Interfaces;

namespace Birdhouse.Common.Conversions
{
    public class BytesToStringConverter 
        : IBytesConverter<string>, IDisposable
    {
        public BytesToStringConverter(bool removeDashes = true)
        {
            if (removeDashes)
            {
                OnProcess += RemoveDashes;
            }

            _removeDashes = removeDashes;
        }
        
        public event Func<string, string> OnProcess = _ => _;

        private readonly bool _removeDashes;

        private static string RemoveDashes(string source)
        {
            var result = source.Replace("-", string.Empty);
            return result;
        }

        public string Convert(byte[] bytes)
        {
            var converted = BitConverter.ToString(bytes);
            
            var result = OnProcess.Invoke(converted);
            return result;
        }

        public void Dispose()
        {
            if (_removeDashes)
            {
                OnProcess -= RemoveDashes;
            }
        }
    }
}