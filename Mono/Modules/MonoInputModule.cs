using System;
using System.Collections.Generic;
using Birdhouse.Common.Helpers;
using Birdhouse.Education.Patterns.Listening;
using Birdhouse.Education.Patterns.Listening.Interfaces;
using Birdhouse.Education.Patterns.Listening.Services;
using Birdhouse.Tools.Inputs.Services;
using Birdhouse.Tools.Inputs.Services.Interfaces;
using Birdhouse.Tools.Inputs.Services.Listeners;
using UnityEngine;

namespace Birdhouse.Mono.Modules
{
    public class MonoInputModule : MonoBehaviour
    {
        [SerializeField] private SerializableListenSettings listenSettings;
        
        [SerializeField] private SerializableMouseInputModule mouseInputModule;
        [SerializeField] private SerializableButtonInputModule buttonInputModule;
        [SerializeField] private SerializableKeyInputModule keyInputModule;
        
        private IPressureService<int> _mousePressureService;
        private IPressureService<string> _buttonPressureService;
        private IPressureService<KeyCode> _keyPressureService;

        private IListenService _listenService;

        private void Awake()
        {
            var tenseController = TenseHelper.Controllers.RealtimeTenseController;
            
            _mousePressureService = new MousePressureService(tenseController);
            _buttonPressureService = new ButtonPressureService(tenseController);
            _keyPressureService = new KeyPressureService(tenseController);

            _listenService = new AsynchronousListenService();
            _listenService.BeginListen(mouseInputModule.CreateListener(_mousePressureService), listenSettings);
            _listenService.BeginListen(buttonInputModule.CreateListener(_buttonPressureService), listenSettings);
            _listenService.BeginListen(keyInputModule.CreateListener(_keyPressureService), listenSettings);
        }
        
        public IPressureService<int> MousePressureService => _mousePressureService;
        public IPressureService<string> ButtonPressureService => _buttonPressureService;
        public IPressureService<KeyCode> KeyPressureService => _keyPressureService;

        [Serializable]
        private abstract class SerializableInputModuleBase<T>
        {
            [SerializeField] private List<T> targetPressures;

            protected abstract IListener CreateListener(IList<T> targetPressures, IPressureService<T> pressureService);

            public IListener CreateListener(IPressureService<T> pressureService)
            {
                return CreateListener(targetPressures, pressureService);
            }
        }

        [Serializable]
        private class SerializableMouseInputModule : SerializableInputModuleBase<int>
        {
            protected override IListener CreateListener(IList<int> targetPressures, IPressureService<int> pressureService)
            {
                var listener = new MousePressureListener(pressureService, InputHelper.MousePressureStateProvider, targetPressures);
                return listener;
            }
        }
        
        [Serializable]
        private class SerializableButtonInputModule : SerializableInputModuleBase<string>
        {
            protected override IListener CreateListener(IList<string> targetPressures, IPressureService<string> pressureService)
            {
                var listener = new ButtonPressureListener(pressureService, InputHelper.ButtonPressureStateProvider, targetPressures);
                return listener;
            }
        }
        
        [Serializable]
        private class SerializableKeyInputModule : SerializableInputModuleBase<KeyCode>
        {
            protected override IListener CreateListener(IList<KeyCode> targetPressures, IPressureService<KeyCode> pressureService)
            {
                var listener = new KeyPressureListener(pressureService, InputHelper.KeyPressureStateProvider, targetPressures);
                return listener;
            }
        }
    }
}