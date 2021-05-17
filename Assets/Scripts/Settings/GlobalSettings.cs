using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Settings
{
    public class GlobalSettings : MonoBehaviour
    {
        [SerializeField] private List<Setting> settings;

        public void SetSetting<T>(string key, T value)
        {
            var item = settings.FirstOrDefault(setting => setting.key == key);
            if (item == null)
            { 
                settings.Add(new Setting(key, typeof(T), value));
            }
            else
            {
                item.value = value;
            }
        }

        public T GetSetting<T>(string key)
        {
            var item = settings.FirstOrDefault(value => value.key == key);
            if (item.type == typeof(T))
            {
                return (T) item.value;
            }
            else
            {
                throw new Exception("Not correct type");
            }
        }
    }
}
