using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Managers;
using ESparrow.Utils.Patterns.Singleton;

namespace ESparrow.Utils.Settings
{
    public class GlobalSettings : UnitySingleton<GlobalSettings>
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

            Save();
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

        private void Save()
        {
            foreach (var setting in settings)
            {
                StorageManager.Set(setting.key, JsonUtility.ToJson(setting.value));
            }
        }

        private void Load()
        {
            foreach (var setting in settings)
            {
                setting.value = StorageManager.Get<string>(setting.key);
            }
        }

        private void Start()
        {
            Load();
        }
    }
}
