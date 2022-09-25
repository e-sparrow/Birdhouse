using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Customization.TypeSerialization;
using Birdhouse.Customization.TypeSerialization.Interfaces;
using Birdhouse.Tools.Filtering.Routine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Birdhouse.Tools.Customization.TypeSerialization.Editor
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