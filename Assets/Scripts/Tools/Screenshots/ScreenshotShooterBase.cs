using ESparrow.Utils.Tools.Screenshots.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Screenshots
{
    public abstract class ScreenshotShooterBase : IScreenshotShooter
    {
        protected ScreenshotShooterBase(Camera camera)
        {
            _camera = camera;
        }

        private readonly Camera _camera;

        protected abstract RenderTexture CreateRenderTexture();
        protected abstract Texture2D CreateTexture();

        public Texture2D Shoot()
        {
            var tempRenderTexture = _camera.targetTexture;
            var renderTexture = CreateRenderTexture();

            _camera.targetTexture = renderTexture;
            _camera.RenderDontRestore();

            var tempActiveRenderTexture = RenderTexture.active;
            RenderTexture.active = renderTexture;
            
            var texture = CreateTexture();

            Reset();
            
            return texture;

            void Reset()
            {
                _camera.targetTexture = tempRenderTexture;
                RenderTexture.active = tempActiveRenderTexture;
            
                Object.Destroy(renderTexture);
            }
        }
    }
}
