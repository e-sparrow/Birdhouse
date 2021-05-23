using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ESparrow.Utils.Settings;
using ESparrow.Utils.Listeners;

namespace ESparrow.Utils.UI
{
    public class KeyField : MonoBehaviour
    {
        [SerializeField] private string keyName;

        [SerializeField] private TMP_Text keyNameText;
        [SerializeField] private TMP_Text keyValueText;

        public void Wait()
        {
            var listener = new PressListener();
            listener.OnAnyKeyPressed += Press;
        }

        private void Press(KeyCode key)
        {
            GlobalSettings.Instance.SetSetting(keyName, key);
            keyValueText.text = key.ToString();
        }

        private void Start()
        {
            keyValueText.text = GlobalSettings.Instance.GetSetting<KeyCode>(keyName).ToString();
        }
    }
}
