using UnityEngine;
using ESparrow.Utils.Patterns.FluentBuilder;

namespace ESparrow.Utils.Builders
{
    public class GameObjectBuilder : BuilderBase<GameObject>
    {
        public GameObjectBuilder SetName(string name)
        {
            _instance.name = name;
            return this;
        }

        public GameObjectBuilder SetParent(Transform transform)
        {
            _instance.transform.SetParent(transform);
            return this;
        }

        public GameObjectBuilder SetTag(string tag)
        {
            _instance.tag = tag;
            return this;
        }

        public GameObjectBuilder SetStatic(bool isStatic)
        {
            _instance.isStatic = isStatic;
            return this;
        }

        public GameObjectBuilder SetLayer(int layer)
        {
            _instance.layer = layer;
            return this;
        }

        public GameObjectBuilder SetLayer(LayerMask layer)
        {
            _instance.layer = layer.value;
            return this;
        }

        public GameObjectBuilder SetHideFlags(HideFlags flags)
        {
            _instance.hideFlags = flags;
            return this;
        }

        public GameObjectBuilder WithComponent<T>() where T : Component
        {
            _instance.AddComponent<T>();
            return this;
        }
    }
}
