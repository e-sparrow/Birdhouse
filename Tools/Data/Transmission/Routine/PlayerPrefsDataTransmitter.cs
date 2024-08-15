using Birdhouse.Tools.Data.Transmission.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Data.Transmission.Routine
{
    public class PlayerPrefsDataTransmitter 
        : IDataTransmitter<string>
    {
        public PlayerPrefsDataTransmitter(string key)
        {
            _key = key;
        }

        private readonly string _key;

        public bool IsValid()
        {
            var result = PlayerPrefs.HasKey(_key);
            return result;
        }

        public string Download()
        {
            var result = PlayerPrefs.GetString(_key);
            return result;
        }

        public void Upload(string data)
        {
            PlayerPrefs.SetString(_key, data);
        }
    }
}