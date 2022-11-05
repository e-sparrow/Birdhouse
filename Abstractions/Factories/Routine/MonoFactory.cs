using Birdhouse.Abstractions.Factories.Interfaces;
using UnityEngine;

namespace Birdhouse.Abstractions.Factories.Routine
{
    public class MonoFactory<T> : IFactory<T>
        where T : MonoBehaviour
    {
        public MonoFactory(T prefab, Transform root = null)
        {
            _prefab = prefab;
            _root = root;
        }

        private readonly T _prefab;
        private readonly Transform _root;
        
        public T Create()
        {
            var result = Object.Instantiate(_prefab, _root);
            return result;
        }
    }
}