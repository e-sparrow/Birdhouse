using System.Collections.Generic;
using Birdhouse.Abstractions.Factories.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Singleton
{
    public class MonoSingletonStrategy<T> : SingletonStrategyBase<T>
        where T : MonoBehaviour
    {
        public MonoSingletonStrategy(IFactory<T> factory) : base(factory)
        {
            
        }
        
        public override IEnumerable<T> FindInstances()
        {
            var result = Object.FindObjectsOfType<T>();
            return result;
        }
    }
}