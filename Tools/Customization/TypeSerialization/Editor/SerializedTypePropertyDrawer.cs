using System.Linq;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Tools.Customization.TypeSerialization.Interfaces;
using ESparrow.Utils.Tools.Filtering.Routine;
using ESparrow.Utils.Tools.Strings.Filtering.Interfaces;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ESparrow.Utils.Tools.Customization.TypeSerialization.Editor
{
    [CustomPropertyDrawer(typeof(SerializedType))]
    public class SerializedTypePropertyDrawer : PropertyDrawer
    {
        private const int ResultsCount = 10;

        private static readonly ITypeContainer Container = new TypeContainer();
        
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var typeNameProperty = property.FindPropertyRelative("typeName");

            var foldout = new Foldout();
            foldout.text = typeNameProperty.displayName;
            
            container.Add(foldout);
            
            var label = new Label("af " + typeNameProperty.stringValue);
            foldout.Add(label);

            var searchField = new ToolbarPopupSearchField();
            searchField.value = typeNameProperty.stringValue;
            
            var allTypes = Container.GetData().Select(value => value.FullName);
            var filter = new PriorityBasedStringFilter(searchField.value, ResultsCount);
            
            var types = filter.Filtrate(allTypes);
            foreach (var type in types)
            {
                searchField.menu.AppendAction(type, Select);

                void Select(DropdownMenuAction action)
                {
                    typeNameProperty.SetValue(type);
                }
            }
            
            foldout.Add(searchField);

            return container;
        }
    }
}