using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Birdhouse.Customization.MonoDrawer.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MonoBehaviourDrawer : UnityEditor.Editor
    {
        private const string Ignore = "m_Script";
        
        public override VisualElement CreateInspectorGUI()
        {
            var container = new VisualElement();

            var property = serializedObject.GetIterator();
            if (!property.NextVisible(true)) 
                return container;
            
            do
            {
                var field = new PropertyField(property);
                if (property.name == Ignore)
                {
                    field.SetEnabled(false);
                }

                container.Add(field);
            } 
            while (property.NextVisible(false));

            return container;
        }
    }
}