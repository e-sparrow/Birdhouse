using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Hotkeys.Interfaces;
using Birdhouse.Tools.Inputs.Services.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Hotkeys
{
    public abstract class VerifyHotkeyBase : IVerifyHotkey
    {
        protected VerifyHotkeyBase
            (IPressureService<KeyCode> pressureService, IEnumerable<KeyCode> keys, bool allowHold, bool allowExcess)
        {
            _pressureService = pressureService;
            _keys = keys;
            _allowHold = allowHold;
            _allowExcess = allowExcess;
        }

        private readonly IPressureService<KeyCode> _pressureService;
        private readonly IEnumerable<KeyCode> _keys;
        private readonly bool _allowHold;
        private readonly bool _allowExcess;

        protected abstract bool Check(IPressureService<KeyCode> pressureService, IEnumerable<KeyCode> keys, out bool hold, out bool excess);

        public bool Check()
        {
            bool check = Check(_pressureService, _keys, out bool hold, out bool excess);
            if (!check) return false;
            
            return (!hold || _allowHold) && (!excess || _allowExcess);
        }
    }
}