using System.Linq;
using UnityEngine;

namespace Birdhouse.Common.Extensions
{
    public static class AnimatorExtensions
    {
        public static bool HasFloat(this Animator self, string name)
        {
            var result = self.HasParameterWithName(name, AnimatorControllerParameterType.Float);
            return result;
        }
        
        public static bool HasFloat(this Animator self, int nameHash)
        {
            var result = self.HasParameterWithHash(nameHash, AnimatorControllerParameterType.Float);
            return result;
        }
        
        public static bool HasInt(this Animator self, string name)
        {
            var result = self.HasParameterWithName(name, AnimatorControllerParameterType.Int);
            return result;
        }
        
        public static bool HasInt(this Animator self, int nameHash)
        {
            var result = self.HasParameterWithHash(nameHash, AnimatorControllerParameterType.Int);
            return result;
        }
        
        public static bool HasBool(this Animator self, string name)
        {
            var result = self.HasParameterWithName(name, AnimatorControllerParameterType.Bool);
            return result;
        }
        
        public static bool HasBool(this Animator self, int nameHash)
        {
            var result = self.HasParameterWithHash(nameHash, AnimatorControllerParameterType.Bool);
            return result;
        }
        
        public static bool HasTrigger(this Animator self, string name)
        {
            var result = self.HasParameterWithName(name, AnimatorControllerParameterType.Trigger);
            return result;
        }
        
        public static bool HasTrigger(this Animator self, int nameHash)
        {
            var result = self.HasParameterWithHash(nameHash, AnimatorControllerParameterType.Trigger);
            return result;
        }

        private static bool HasParameterWithName(this Animator self, string name, AnimatorControllerParameterType type)
        {
            var result = self
                .parameters
                .Any(value =>
                value.type == type && 
                value.name == name);
            
            return result;
        }

        private static bool HasParameterWithHash(this Animator self, int nameHash, AnimatorControllerParameterType type)
        {
            var result = self
                .parameters
                .Any(value =>
                value.type == type && 
                value.nameHash == nameHash);
            
            return result;
        }
    }
}