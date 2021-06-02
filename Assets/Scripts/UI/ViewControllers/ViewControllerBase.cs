using System;
using UnityEngine;

namespace ESparrow.Utils.UI.ViewControllers
{
    public abstract class ViewControllerBase : MonoBehaviour
    {
        public Action<bool> OnActiveStateChanged;

        [SerializeField] private GameObject panel;

        [SerializeField] private bool closePrevious; // Закрывать предыдущее окно при открытии этого.
        [SerializeField] private bool defaultActive; // Должен ли ViewController быть открыт по запуску игры.

        private bool _isActive; // Открыто ли окно. По умолчанию закрыто. Чтобы открыть, нужно вызвать метод Open.

        public void Toggle()
        {
            switch (_isActive)
            {
                case true: 
                    Close();
                    break;
                case false:
                    Open();
                    break;
            }
        }

        public void Open()
        {
            Open(closePrevious);
        }

        public void Open(bool closePrevious)
        {
            ViewControllersManager.Open(this, closePrevious);
        }

        public void Close()
        {
            if (_isActive && ViewControllersManager.IsCurrent(this))
            {
                ViewControllersManager.Back();
            }
        }

        public void SetActive(bool active)
        {
            _isActive = active;

            panel.gameObject.SetActive(_isActive);
            OnActiveStateChanged?.Invoke(_isActive);
        }

        private void Start()
        {
            SetActive(defaultActive);
        }

        private void OnValidate()
        {
            SetActive(defaultActive);
        }
    }
}
