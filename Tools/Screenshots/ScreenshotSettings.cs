using Birdhouse.Tools.Screenshots.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Screenshots
{
    public readonly struct ScreenshotSettings : IScreenshotSettings
    {
        public ScreenshotSettings
        (
            Vector2Int size, 
            int depth = 24, 
            int antiAliasing = 8, 
            int anisoLevel = 9, 
            bool mipChain = false,
            bool linear = true,
            TextureFormat textureFormat = TextureFormat.ARGB32, 
            FilterMode filterMode = FilterMode.Point
        )
        {
            Size = size;
            Depth = depth;
            AntiAliasing = antiAliasing;
            AnisoLevel = anisoLevel;
            MipChain = mipChain;
            Linear = linear;
            TextureFormat = textureFormat;
            FilterMode = filterMode;
        }
        
        public Vector2Int Size
        {
            get;
        }

        public int Depth
        {
            get;
        }

        public int AntiAliasing
        {
            get;
        }

        public int AnisoLevel
        {
            get;
        }

        public bool MipChain
        {
            get;
        }

        public bool Linear
        {
            get;
        }

        public TextureFormat TextureFormat
        {
            get;
        }

        public FilterMode FilterMode
        {
            get;
        }
    }
}
