using System;
using System.Linq;
using Birdhouse.Tools.Inputs.Hotkeys.Interfaces;
using Birdhouse.Tools.Inputs.Pressures;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Hotkeys
{
    public abstract class HotkeyListenerBase<TKey, TTime>
        : IHotkeyListener
        where TTime : IComparable<TTime>
    {
        public HotkeyListenerBase(HotkeyInfo<TKey> hotkeyInfo, IPressureListener<TKey, TTime> pressureListener)
        {
            _hotkeyInfo = hotkeyInfo;
            _pressureListener = pressureListener;
        }

        private readonly HotkeyInfo<TKey> _hotkeyInfo;
        private readonly IPressureListener<TKey, TTime> _pressureListener;

        private readonly IDisposable _token;

        public event Action<bool> OnValueChanged = _ => { };

        public bool Value
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _token.Dispose();
        }

        private void Subscribe()
        {
            var keys = _hotkeyInfo.Keys.ToArray();
            throw new NotImplementedException();
        }
    }
}