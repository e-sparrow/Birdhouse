using Birdhouse.Common.Extensions;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Customization.SerializableAdapters.Editor
{
    [CustomPropertyDrawer(typeof(ComponentAdapter<>))]
    public class ComponentAdapterEditor
        : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            DropAreaGUI(position, property);
            
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PropertyField(position, property, label);
            
            EditorGUI.EndProperty();
        }
        
        public void DropAreaGUI(Rect dropArea, SerializedProperty property)
        {
            Event evt = Event.current;
            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(evt.mousePosition) || DragAndDrop.objectReferences.Length > 1)
                        return;

                    var draggedObject = DragAndDrop.objectReferences[0];
                    var adapter = property.serializedObject
                            .FindProperty("adapter")
                            .FindPropertyRelative("target");

                    var isAdapted = false;
                    if (!isAdapted)
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                        return;
                    }

                    DragAndDrop.visualMode = DragAndDropVisualMode.Link;
                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();
                        
                        property.serializedObject.ApplyModifiedProperties();
                        property.serializedObject.Update();
                    }
                    
                    evt.Use();
                    break;
            }
        }
    }
}