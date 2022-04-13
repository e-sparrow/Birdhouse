using System;
using System.Collections;
using System.Threading.Tasks;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Easing.Interfaces;
using ESparrow.Utils.Tools.Graduating.Interfaces;

namespace ESparrow.Utils.Extensions
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