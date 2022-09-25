using System;
using System.Collections;
using System.Threading.Tasks;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Easing.Interfaces;
using Birdhouse.Tools.Graduating.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class TweeningExtensions
    {
        public static IEnumerator Tween<T>(this T self, Action<T, float> action, float duration, IEase ease = default)
        {
            return CoroutinesHelper.Graduate(SetProgress, duration, ease);
            
            void SetProgress(float progress)
            {
                action.Invoke(self, progress);
            }
        }
        
        public static IEnumerator Tween<T>(this T self, Action<T, float> action, ITweeningSettings settings)
        {
            return CoroutinesHelper.Graduate(SetProgress, settings);

            void SetProgress(float progress)
            {
                action.Invoke(self, progress);
            }
        }

        public static async Task TweenAsync<T>(this T self, Action<T, float> action, float duration, TimeSpan step, IEase ease = default)
        {
            await AsyncHelper.Graduate(SetProgress, duration, step, ease);
            
            void SetProgress(float progress)
            {
                action.Invoke(self, progress);
            }
        }

        public static async Task TweenAsync<T>(this T self, Action<T, float> action, float duration, int step, IEase ease = default)
        {
            await AsyncHelper.Graduate(SetProgress, duration, step, ease);
            
            void SetProgress(float progress)
            {
                action.Invoke(self, progress);
            }
        }
    }
}