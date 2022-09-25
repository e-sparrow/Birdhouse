using Birdhouse.Tools.Screenshots.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Screenshots
{
    public class ScreenshotShooter : ScreenshotShooterBase
    {
        public ScreenshotShooter(Camera camera, IScreenshotSettings screenshotSettings) : base(camera)
        {
            _screenshotSettings = screenshotSettings;
        }

        private readonly IScreenshotSettings _screenshotSettings;

        protected override RenderTexture CreateRenderTexture()
        {
            var texture = new RenderTexture(_screenshotSettings.Size.x, _screenshotSettings.Size.y, 0)
            {
                depth = _screenshotSettings.Depth,
                antiAliasing = _screenshotSettings.AntiAliasing,
                anisoLevel = _screenshotSettings.AnisoLevel
            };

            return texture;
        }

        protected override Texture2D CreateTexture()
        {
            var texture = new Texture2D
            (
                _screenshotSettings.Size.x, 
                _screenshotSettings.Size.y, 
                    _screenshotSettings.TextureFormat, 
                    _screenshotSettings.MipChain, 
                    _screenshotSettings.Linear
            );
            
            var rect = new Rect(0, 0, _screenshotSettings.Size.x, _screenshotSettings.Size.y);
            
            texture.ReadPixels(rect, 0, 0);
            texture.filterMode = _screenshotSettings.FilterMode;
            
            texture.Apply();

            return texture;
        }
    }
}
