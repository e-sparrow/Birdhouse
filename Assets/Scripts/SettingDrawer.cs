using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using ESparrow.Utils.Settings;

[CustomPropertyDrawer(typeof(Setting))]
public class SettingDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var nameField = new PropertyField(property.FindPropertyRelative("type"));
        var str = new PropertyField(property.FindPropertyRelative("str"));

        container.Add(nameField);
        container.Add(str);

        return container;
    }
}
