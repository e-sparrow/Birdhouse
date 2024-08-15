// TODO:
#if UNITY_EDITOR_WIN
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Birdhouse.Common.Assertions;
using Birdhouse.Common.Binaries;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Logical;
using Birdhouse.Tools.Data.Transmission;
using Birdhouse.Tools.Data.Transmission.Adapters;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization;
using Birdhouse.Tools.Serialization.Unity;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Birdhouse.Tools.Windows.Defender.Editor
{
	public static class WindowsDefenderProjectExcluder
    {
        private const string MenuPath = "Birdhouse/Tools/Windows/Defender/Exclude Project";

        private const string CmdFileName = "cmd.exe";
        private const string AdminVerb = "runas";
        
        private const string Title = "Birdhouse Windows Defender Excluder";
        private const string Message = "Exclude this project from Windows Defender?";
        private const string Yes = "Yes";
        private const string No = "No";
        private const string Ignore = "No, don't ask again";

        private const string MetaDataFileName = "Assets/Birdhouse/MicrosoftDefenderMeta.data";
        
        private static readonly string DenyWarning = $"You just denied offer to exclude your project from Windows Defender. If you'll change your mind just click on the menu button by path \"{MenuPath}\"";
        
        private static readonly string DontAskAgainKey = $"{nameof(WindowsDefenderProjectExcluder)}.DontAskAgain";
        private static readonly string ExclusionDoneKey = $"{nameof(WindowsDefenderProjectExcluder)}.ExclusionDone";
        private static readonly string InitializedKey = $"{nameof(WindowsDefenderProjectExcluder)}.Initialized";

        private static readonly string MetaDataPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), MetaDataFileName);
        
        private static readonly IAsyncDataTransmitter<MicrosoftDefenderMetaData> MetaData  
            = new MicrosoftDefenderMetaDataTransmitter(MetaDataPath);

        [InitializeOnLoadMethod]
        private static async void Initialize()
        {
            var tempMeta = MetaData.IsValid() ? await MetaData.GetData() : new MicrosoftDefenderMetaData(false, false, false);
            
            var isInitialized = tempMeta.IsInitialized;
            var exclusionDone = tempMeta.ExclusionDone;
            var dontAskAgain = tempMeta.DontAskAgain;
            
            if (dontAskAgain || exclusionDone)
            {
                return;
            }

            if (!isInitialized)
            {
                isInitialized = true;
                
                var path = Path.GetDirectoryName(Application.dataPath);
                var response = EditorUtility.DisplayDialogComplex(Title, Message, Yes, No, Ignore);

                switch (response)
                {
                    case 0:
                        ExcludeDirectory(path);
                        exclusionDone = true;
                        break;
                
                    case 1:
                        Debug.LogWarning(DenyWarning);
                        break;
                
                    case 2:
                        dontAskAgain = true;
                        break;
                }
            }

            var data = new MicrosoftDefenderMetaData(true, exclusionDone, dontAskAgain);
            await MetaData.SetData(data);
        }
        
        [MenuItem(MenuPath)]
        private static void ExcludeProject()
        {
            var path = Path.GetDirectoryName(Application.dataPath);
            ExcludeDirectory(path);
        }

        private static void ExcludeDirectory(string directory)
        {
            var process = CreateExcludeProcess(directory);
            process.Start();
        }

        private static Process CreateExcludeProcess(string directory)
        {
            var result = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo
                {
                    FileName = CmdFileName,
                    Arguments = "/c " + $"powershell -Command Add-MpPreference -ExclusionPath \"{directory}\"; pause",
                    Verb = AdminVerb,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    UseShellExecute = true,
                }
            };

            return result;
        }

        private readonly struct MicrosoftDefenderMetaData
        {
            public MicrosoftDefenderMetaData(bool isInitialized, bool exclusionDone, bool dontAskAgain)
            {
                IsInitialized = isInitialized;
                ExclusionDone = exclusionDone;
                DontAskAgain = dontAskAgain;
            }

            public bool IsInitialized
            {
                get;
            }
            
            public bool ExclusionDone
            {
                get;
            }

            public bool DontAskAgain
            {
                get;
            }
        }
        
        private sealed class MicrosoftDefenderMetaDataTransmitter 
            : FileTransmitterBase<MicrosoftDefenderMetaData>
        {
            public MicrosoftDefenderMetaDataTransmitter(string path) 
                : base(path)
            {
                
            }

            protected override byte[] ToBytes(MicrosoftDefenderMetaData value)
            {
                var array = new BitArray(8)
                {
                    [0] = value.IsInitialized,
                    [1] = value.ExclusionDone,
                    [2] = value.DontAskAgain
                };

                var result = array
                    .ConvertToByte()
                    .AsSingleArray();
                
                return result;
            }

            protected override MicrosoftDefenderMetaData FromBytes(byte[] value)
            {
                var array = new BitArray(value)
                    .Cast<bool>()
                    .ToArray();
                
                var isInitialized = array[0];
                var exclusionDone = array[1];
                var dontAskAgain = array[2];

                var result = new MicrosoftDefenderMetaData(isInitialized, exclusionDone, dontAskAgain);
                return result;
            }
        }
    }
}
#endif
