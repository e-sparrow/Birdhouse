using Birdhouse.Common.Engines.Enums;

namespace Birdhouse.Common.Engines
{
    public static class EngineHelper
    {
        public static EEngine GetCurrentEngine()
        {
#if UNITY_EDITOR || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX || UNITY_EMBEDDED_LINUX || UNITY_QNX || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_SERVER || UNITY_IOS || UNITY_IPHONE || UNITY_ANDROID || UNITY_TVOS || UNITY_WSA || UNITY_WSA_10_0 || UNITY_WEBGL || UNITY_ANALYTICS || UNITY_ASSERTIONS || UNITY_64
            return EEngine.Unity;
#endif

            return EEngine.Unknown;
        }
    }
}