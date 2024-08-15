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

        public static IDisposable RegisterValue(this IFeatureFactory self, object value)
        {
            var result = self.Register(value.GetType(), () => value);
            return result;
        }

        public static IDisposable RegisterValue<T>(this IFeatureFactory self, T value)
        {
            var result = self.Register(typeof(T), () => value);
            return result;
        }

        public static T1 RegisterValue<T1, T2>(this IFeatureFactory<T1> self, T2 value)
        {
            var result = self.Register(typeof(T2), () => value);
            return result;
        }

        public static IDisposable RegisterValue<T, TBase>(this IFeatureFactory self, T value)
            where T : TBase
        {
            var result = self.Register(typeof(TBase), () => value);
            return result;
        }

        public static IDisposable RegisterWithCallback<T>(this IFeatureFactory self, Func<T> func, Action<T> callback)
        {
            var result = self.Register(typeof(T), CreateValue);
            return result;

            object CreateValue()
            {
                var value = func.Invoke();
                callback.Invoke(value);

                return value;
            }
        }

        public static IDisposable RegisterWithCallback<T>(this IFeatureFactory self, T value, Action<T> callback)
        {
            var result = self.Register(typeof(T), CreateValue);
            return result;

            object CreateValue()
            {
                callback.Invoke(value);
                return value;
            }
        }

        public static IDisposable RegisterWithCallback<T>(this IFeatureFactory self, Func<T> func, Action callback)
        {
            var result = self.Register(typeof(T), CreateValue);
            return result;

            object CreateValue()
            {
                var value = func.Invoke();
                callback.Invoke();

                return value;
            }
        }

        public static IDisposable RegisterWithCallback<T>(this IFeatureFactory self, T value, Action callback)
        {
            var result = self.Register(typeof(T), CreateValue);
            return result;

            object CreateValue()
            {
                callback.Invoke();
                return value;
            }
        }

        public static IDisposable RegisterInterfaces<T>(this IFeatureFactory self, T value)
        {
            var result = new CompositeDisposable();

            var interfaces = typeof(T).GetInterfaces();
            foreach (var @interface in interfaces)
            {
                var token = self.Register(@interface, () => value);
                result.Append(token);
            }

            return result;
        }

        public static IFeatureContainer AsContainer(this IFeatureFactory self)
        {
            return self;
        }

        public static IFeatureContainer AsContainer<T>(this IFeatureFactory<T> self)
        {
            return self;
        }
    }
}   