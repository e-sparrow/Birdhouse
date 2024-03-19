using Birdhouse.Features.DI.Interfaces;
using UnityEngine;

namespace Birdhouse.Features.DI.Unity
{
    public abstract class MonoInjectorBase 
        : MonoBehaviour, IInjector
    {
        protected abstract IContainer GetContainer();
        
        public abstract void Install(IContainer container);

        private void Awake()
        {
            var container = GetContainer();
            Install(container);
        }
    }
}