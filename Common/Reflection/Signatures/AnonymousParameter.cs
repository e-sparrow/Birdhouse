using System;
using Birdhouse.Common.Reflection.Misc.Enums;

namespace Birdhouse.Common.Reflection.Signatures
{
    public readonly struct AnonymousParameter
    {
        public AnonymousParameter(EParameterModifiers modifier, Type parameterType, bool isOptional)
        {
            Modifier = modifier;
            ParameterType = parameterType;
            IsOptional = isOptional;
        }
        
        public EParameterModifiers Modifier
        {
            get;
        }

        public Type ParameterType
        {
            get;
        }

        public bool IsOptional
        {
            get;
        }
    }
}