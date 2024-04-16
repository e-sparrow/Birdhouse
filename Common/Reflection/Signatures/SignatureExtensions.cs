using System;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Reflection.Misc.Enums;

namespace Birdhouse.Common.Reflection.Signatures
{
    public static class SignatureExtensions
    {
        public static Signature GetSignature(this MethodInfo self)
        {
            var accessModifier = self.GetAccessModifier();
            var isStatic = self.IsStatic;
            var returnType = self.ReturnType;
            var parameters = self
                .GetParameters()
                .Select(value => value.GetInfo());

            var result = new Signature(accessModifier, isStatic, returnType, parameters);
            return result;
        }

        public static Signature GetSignature(this ConstructorInfo self)
        {
            var accessModifier = self.GetAccessModifier();
            var isStatic = self.IsStatic;
            var returnType = self.DeclaringType;
            var parameters = self
                .GetParameters()
                .Select(value => value.GetInfo());

            var result = new Signature(accessModifier, isStatic, returnType, parameters);
            return result;
        }

        public static AnonymousParameter GetInfo(this ParameterInfo self)
        {
            var result = new AnonymousParameter(self.GetModificator(), self.ParameterType, self.IsOptional);
            return result;
        }

        public static EParameterModifiers GetModificator(this ParameterInfo self)
        {
            if (self.IsRef())
            {
                return EParameterModifiers.Ref;
            }

            if (self.IsOut)
            {
                return EParameterModifiers.Out;
            }

            if (self.IsIn)
            {
                return EParameterModifiers.In;
            }

            return EParameterModifiers.None;
        }

        public static bool IsRef(this ParameterInfo self)
        {
            var result = self.IsOut && self.IsIn && self.ParameterType.IsByRef;
            return result;
        }

        public static EAccessModifiers GetAccessModifier(this MethodBase self)
        {
            if (self.IsPrivate)
                return EAccessModifiers.Private;
            if (self.IsFamily)
                return EAccessModifiers.Protected;
            if (self.IsFamilyOrAssembly)
                return EAccessModifiers.ProtectedInternal;
            if (self.IsAssembly)
                return EAccessModifiers.Internal;
            if (self.IsPublic)
                return EAccessModifiers.Public;

            throw new ArgumentException($"Unknown access modifier found in method {self}!");
        }
    }
}