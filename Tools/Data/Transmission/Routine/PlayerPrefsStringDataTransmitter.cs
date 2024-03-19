using Birdhouse.Tools.Data.Transmission.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Data.Transmission.Routine
{
    public class PlayerPrefsStringDataTransmitter : IDataTransmitter<string>
    {
        public PlayerPrefsStringDataTransmitter(string key)
        {
            _key = key;
        }

        private readonly string _key;

        public bool IsValid()
        {
            var result = PlayerPrefs.HasKey(_key);
            return result;
        }

        public string DownloadData()
        {
            var result = PlayerPrefs.GetString(_key);
            return result;
        }

        public void UploadData(string data)
        {
            PlayerPrefs.SetString(_key, data);
        }
    }
}