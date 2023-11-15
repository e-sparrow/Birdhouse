using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Inputs.AnyKey.Interfaces;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Remapping.Decorators;
using Birdhouse.Tools.Inputs.Unity;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Remapping.Samples
{
    // TODO: Make an editor window or scriptable remapper for Unity
    public class EnumRemapperSample : MonoBehaviour
    {
        private readonly EnumRemapper<EActionCode, KeyCode> _remapper = new EnumRemapper<EActionCode, KeyCode>();

        private IPressureStateProvider<EActionCode> _pressureStateProvider;
        private IAnyKeyListener<EActionCode> _anyKeyListener;

        private IAnyKeyPressureListener<EActionCode> _listener;

        private void Awake()
        {
            _remapper.Initialize();
            
            _pressureStateProvider = UnityInputHelper
                .KeyCodeStateProvider
                .Value
                .Remap(_remapper);

            _anyKeyListener = UnityInputHelper
                .AnyKeyListener
                .Value
                .Remap(_remapper);
            
            _listener = _anyKeyListener.RegisterListener(EPressureState.Pressed);
        }
    }
}