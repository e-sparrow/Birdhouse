using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Inputs.Hotkeys.Interfaces;
using ESparrow.Utils.Inputs.Pressures.Enums;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Services.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Inputs.Hotkeys
{
    public class VerifyHotkey : VerifyHotkeyBase
    {
        public VerifyHotkey(IPressureService<KeyCode> pressureService, IHotkeyInfo info) 
            : base(pressureService, info.Keys, info.AllowHold, info.AllowExcess)
        {
            _sequence = info.Sequence;
        }

        private readonly bool _sequence;

        protected override bool Check(IPressureService<KeyCode> pressureService, IEnumerable<KeyCode> keys, out bool hold, out bool excess)
        {
            hold = false;
            excess = false;
            
            var activeKeys = GetActivations();
            if (activeKeys == null || !activeKeys.Any()) return false;

            var all = activeKeys.Select(value => value.Info.Pressure);
            bool allPressed = keys.All(value => all.Contains(value));
            
            excess = all.Count() > keys.Count();
            hold = keys.All(value => value.IsKeyAtState(EPressureState.Holden));
            
            if (!allPressed) return false;
            if (!_sequence) return true;

            float minTime = 0f;
            foreach (var pressure in activeKeys)
            {
                if (pressure.ActivationTime > minTime)
                {
                    minTime = pressure.ActivationTime;
                }
                else
                {
                    return false;
                }
            }

            return true;

            IEnumerable<IPressureActivation<IPressureInfo<KeyCode>, KeyCode>> GetActivations()
            {
                var list = new List<IPressureActivation<IPressureInfo<KeyCode>, KeyCode>>();
                foreach (var key in keys)
                {
                    var activation = pressureService.GetPressureActivation(key);
                    if (activation != null && activation.Info.State != EPressureState.Untouched)
                    {
                        list.Add(activation);
                    }
                }

                return list;
            }
        }
    }
}