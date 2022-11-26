using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Birdhouse.Extended.BuildTools
{
    public class BuildConfigurator : EditorWindow
    {
        [MenuItem("Window/UI Toolkit/BuildConfigurator")]
        public static void ShowExample()
        {
            BuildConfigurator wnd = GetWindow<BuildConfigurator>();
            wnd.titleContent = new GUIContent("BuildConfigurator");
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            VisualElement label = new Label("Hello World! From C#");
            root.Add(label);

            // Import UXML
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Birdhouse/Extended/BuildTools/BuildConfigurator.uxml");
            VisualElement labelFromUXML = visualTree.Instantiate();
            root.Add(labelFromUXML);

            // A stylesheet can be added to a VisualElement.
            // The style will be applied to the VisualElement and all of its children.
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Birdhouse/Extended/BuildTools/BuildConfigurator.uss");
            VisualElement labelWithStyle = new Label("Hello World! With Style");
            labelWithStyle.styleSheets.Add(styleSheet);
            root.Add(labelWithStyle);
        }
    }
}