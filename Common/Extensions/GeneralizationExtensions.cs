using System;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Generalization.Errors.Interfaces;
using Birdhouse.Tools.Generalization.Multiplying.Interfaces;
using Birdhouse.Tools.Generalization.Summation.Interfaces;
using Birdhouse.Tools.Generalization.Types.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class GeneralizationExtensions
    {
        public static IErroneous<T> AsErroneous<T>(this T self)
        {
            return self.FindGeneralizationAdapter<T, IErroneous<T>>();
        }

        public static IMultipliable<T> AsMultipliable<T>(this T self)
        {
            return self.FindGeneralizationAdapter<T, IMultipliable<T>>();
        }

        public static ISummable<T> AsSummable<T>(this T self)
        {
            return self.FindGeneralizationAdapter<T, ISummable<T>>();
        }

        /// <summary>
        /// Converts self value to TTo type if it's a generalization type.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <typeparam name="TFrom">Type to convert from it</typeparam>
        /// <typeparam name="TAdapter">Type to convert to it</typeparam>
        /// <returns>TTo value from TFrom value</returns>
        public static TAdapter FindGeneralizationAdapter<TFrom, TAdapter>(this TFrom self) where TAdapter : IGeneralizationAdapter
        {
            bool isGeneralizationType = GeneralizationHelper.IsGeneralizationType(self);
            if (!isGeneralizationType && !IsConstructorArgument()) return default;

            var subclasses = typeof(TAdapter).GetSubclasses();
            var enumerable = subclasses.ToArray();
            if (!enumerable.Contains(self.GetType())) return default;

            var targetType = enumerable.FirstOrDefault(IsTargetType);
            if (targetType == null) return default;

            if (isGeneralizationType)
            {
                var argument = self.AsSingleEnumerable();
                return (TAdapter) Activator.CreateInstance(targetType, argument);
            }
            else
            {
                var argument = GetTargetConstructor().GetParameters();
                return (TAdapter) Activator.CreateInstance(targetType, argument);
            }
            
            ConstructorInfo GetTargetConstructor()
            {
                return typeof(TAdapter).GetConstructors().FirstOrDefault(IsTargetConstructor);

                bool IsTargetConstructor(ConstructorInfo constructor)
                {
                    return Equals(constructor.GetParameters().AsEnumerable(), self.AsSingleEnumerable());
                }
            }
            
            bool IsConstructorArgument()
            {
                return !GetTargetConstructor().Equals(default);
            }

            bool IsTargetType(Type value)
            {
                return self.GetType() == value;
            }
        }
    }
}
