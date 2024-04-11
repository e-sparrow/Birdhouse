using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public static class FeatureExtensions
    {
        public static bool TryGetFeature<T>(this IFeatureContainer self, out T result)
        {
            result = default;
            
            var hasFeature = self.TryGetFeature(typeof(T), out var feature);
            if (hasFeature)
            {
                result = (T) feature;
            }

            return hasFeature;
        }

        public static void UseFeature<T>(this IFeatureContainer self, Action<T> callback, Action onAbsent = null)
        {
            onAbsent ??= () => { };

            var hasFeature = self.TryGetFeature<T>(out var feature);
            if (hasFeature)
            {
                callback.Invoke(feature);
            }
            else
            {
                onAbsent.Invoke();
            }
        }

        public static void UseFeatureOrThrow<T>(this IFeatureContainer self, Action<T> callback, Func<Exception> onAbsent)
        {
            self.UseFeature(callback, HandleAbsent);

            void HandleAbsent()
            {
                throw onAbsent.Invoke();
            }
        }

        public static void UseFeatureOrThrow<T>(this IFeatureContainer self, Action<T> callback, Exception onAbsent)
        {
            self.UseFeature(callback, HandleAbsent);

            void HandleAbsent()
            {
                throw onAbsent;
            }
        }

        public static IDisposable RegisterParameter<T>(this IFeatureFactory self, T parameter)
        {
            var result = self.RegisterParameter(typeof(T), parameter);
            return result;
        }

        public static IDisposable RegisterBase<T, TBase>(this IFeatureFactory self, T parameter)
            where T : TBase
        {
            var result = self.RegisterParameter(typeof(TBase), parameter);
            return result;
        }

        public static IDisposable RegisterInterfaces<T>(this IFeatureFactory self, T parameter)
        {
            var result = new CompositeDisposable();

            var interfaces = typeof(T).GetInterfaces();
            foreach (var @interface in interfaces)
            {
                var token = self.RegisterParameter(@interface, parameter);
                result.Append(token);
            }

            return result;
        }

        public static IFeatureContainer AsContainer(this IFeatureFactory self)
        {
            return self;
        }
    }
}   