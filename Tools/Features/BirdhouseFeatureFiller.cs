using System;
using System.Linq;
using System.Reflection;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Abstractions.Disposables.Interfaces;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public static class BirdhouseFeatureFiller
    {
        public static IDisposable FillTo<T>(IFeatureFactory factory)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(value => value.HasCustomAttribute<BirdhouseFeatureAttribute>());

            ICompositeDisposable token = new CompositeDisposable();
            foreach (var type in types)
            {
                var hasValidConstructor = type
                    .GetConstructors()
                    .TryGetFirst(IsValidConstructor, out var constructor);

                if (hasValidConstructor)
                {
                    var featureToken = factory.RegisterFeature(type, value => constructor.Invoke(new object[]
                    {
                        value
                    }));
                    
                    token = token.Append(featureToken);
                }

                bool IsValidConstructor(ConstructorInfo constructorInfo)
                {   
                    var parameters = constructorInfo.GetParameters();
                    
                    var result = parameters.Length == 1 && parameters.First().ParameterType == typeof(T);
                    return result;
                }
            }

            return token;
        }
    }
}