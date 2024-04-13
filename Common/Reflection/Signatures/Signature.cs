using System;
using System.Collections.Generic;
using Birdhouse.Common.Reflection.Signatures.Enums;

namespace Birdhouse.Common.Reflection.Signatures
{
    public readonly struct Signature
    {
        public Signature
        (
            EAccessModifiers accessModifier,
            bool isStatic,
            Type returnType, 
            IEnumerable<AnonymousParameter> parameters
        )
        {
            AccessModifier = accessModifier;
            IsStatic = isStatic;
            ReturnType = returnType;
            Parameters = parameters;
        }

        public EAccessModifiers AccessModifier
        {
            get;
        }
        
        public bool IsStatic
        {
            get;
        }
        
        public Type ReturnType
        {
            get;
        }

        public IEnumerable<AnonymousParameter> Parameters
        {
            get;
        }
    }
}