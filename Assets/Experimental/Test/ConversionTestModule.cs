using System;
using ESparrow.Utils.Conversion.Enums;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Test.Examples;
using UnityEngine;

namespace ESparrow.Utils.Test
{
    [Serializable]
    public class ConversionTestModule : TestModuleBase
    {
        public override void Test()
        {
            var original = new OriginalConversionExample();
            
            // Should equal true because OriginalConversionExample has method without parameters with return type of FinalConversionExample
            var finalByMethod = ConversionHelper.TryConvert(original, out FinalConversionExample byMethod, EConversionType.Method);
            
            // Should equal true because FinalConversionExample has constructor with one parameter of type OriginalConversionExample
            var finalByConstructor = ConversionHelper.TryConvert(original, out FinalConversionExample byConstructor, EConversionType.Constructor);
            
            // Should equal true because OriginalConversionExample has implicit operators with return type FinalConversionExample
            var finalByImplicitOperator = ConversionHelper.TryConvert(original, out FinalConversionExample byImplicitOperator, EConversionType.ImplicitOperator);
            
            // Should equal false, because OriginalConversionExample has no explicit operators with return type FinalConversionExample
            var finalByExplicitOperator = ConversionHelper.TryConvert(original, out FinalConversionExample byExplicitOperator, EConversionType.ExplicitOperator);

            Debug.Log($"Converted successfully by:" +
                      $"\nMethod: {finalByMethod}" +
                      $"\nConstructor: {finalByConstructor}" +
                      $"\nImplicit operator: {finalByImplicitOperator}" +
                      $"\nExplicit operator: {finalByExplicitOperator}");
        }
    }
}
