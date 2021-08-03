using System;
using UnityEngine;

namespace ESparrow.Utils.UI.ViewControllers
{
    public abstract class ViewControllerBase : MonoBehaviour
    {
        public Action<bool> OnActiveStateChanged;

        [SerializeField] protected GameObject panel;

        [SerializeField] private bool closePrevious; // Закрывать предыдущее окно при открытии этого.
        [SerializeField] private bool defaultActive; // Должен ли ViewController быть открыт по запуску игры.

        private bool _active; // Открыто ли окно. По умолчанию закрыто. Чтобы открыть, нужно вызвать метод Open.

        public bool Active => _active;

        private ViewControllersManager _viewControllersManager;

        public void Toggle()
        {
            _active = !_active;

            if (_active)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        public void Open()
        {
            Open(closePrevious);
        }

        public void Open(bool closePrevious)
        {
            _viewControllersManager.Open(this, closePrevious);
        }

        public void Close()
        {
            _viewControllersManager.Close();
        }

        public void Back()
        {
            if (_active && _viewControllersManager.IsCurrent(this))
            {
                _viewControllersManager.Back();
            }
        }

        public void SetActive(bool active)
        {
            _active = active;

            panel.gameObject.SetActive(_active);
            OnActiveStateChanged?.Invoke(_active);
        }

        private void Start()
        {
            SetActive(defaultActive);
        }

        private void OnValidate()
        {
            SetActive(defaultActive);
        }

        private void OnEnable()
        {
            _viewControllersManager.Register(this);
        }

        private void OnDisable()
        {
            _viewControllersManager.Unregister(this);
        }
    }
}
