using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Tools.Equality.Interfaces
{
    public interface IEqualityComparer<in TSelf, in TOther>
    {
        /// <summary>
        /// Checks self and another values for equality.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another value</param>
        /// <returns>True if self value equals another one and false otherwise</returns>
        bool Equals(TSelf self, TOther other);
    }
    
    public interface IEqualtyComparer<T> : IEqualityComparer<T, T>
    {
        
    }
}
