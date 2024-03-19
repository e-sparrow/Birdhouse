using System;
using UnityEngine.LowLevel;

namespace Birdhouse.Tools.UnityMessages
{
    public static class PlayerLoopExtensions
    {
        public static ref PlayerLoopSystem Find<T>(this ref PlayerLoopSystem self)
        {
            ref var result = ref self.Find(typeof(T));
            return ref result;
        }

        public static ref PlayerLoopSystem Find(this ref PlayerLoopSystem self, Type type)
        {
            for (var i = 0; i < self.subSystemList.Length; i++)
            {
                if (self.subSystemList[i].type == type)
                {
                    return ref self.subSystemList[i];
                }
            }

            throw new Exception($"System of type '{type.Name}' not found inside loop '{self.type.Name}'.");
        }
    }
}