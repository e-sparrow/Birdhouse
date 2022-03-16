using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace ESparrow.Utils.Tools.Screenshots.Interfaces
{
    public interface IScreenshotSettings
    {
        Vector2Int Size
        {
            get;
        }
        
        int Depth
        {
            get;
        }

        int AntiAliasing
        {
            get;
        }

        int AnisoLevel
        {
            get;
        }

        bool MipChain
        {
            get;
        }

        bool Linear
        {
            get;
        }

        TextureFormat TextureFormat
        {
            get;
        }

        FilterMode FilterMode
        {
            get;
        }
    }
}
