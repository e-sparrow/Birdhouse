using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ESparrow.Utils.Generalization.Errors.Interfaces;
using ESparrow.Utils.Generalization.Interfaces;
using ESparrow.Utils.Tools.Interpolation.Interfaces;
using ESparrow.Utils.Generalization.Multiplying.Interfaces;
using ESparrow.Utils.Generalization.Summation.Interfaces;
using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools;
using ESparrow.Utils.Generic.References;

namespace ESparrow.Utils.Extensions
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
