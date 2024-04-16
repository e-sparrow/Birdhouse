using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Misc.Enums;

namespace Birdhouse.Common.Reflection.Misc
{
    public static class AccessModifierExtensions
    {
        // TODO: Naming question
        public static string AsVanillaModifier(this EAccessModifiers self)
        {
            var result = string.Join(' ', self
                .ToString()
                .SplitCamelCase())
                .ToLower();

            return result;
        }
    }
}