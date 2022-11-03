using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class BuildConfigurationWindow : EditorWindow
{
    private const string Title = "BuildConfigurationWindow";
    private const string MenuItemName = "Window/UI Toolkit/BuildConfigurationWindow";
    
    [MenuItem(MenuItemName)]
    public static void ShowWindow()
    {
        var window = GetWindow<BuildConfigurationWindow>();
        window.titleContent = new GUIContent(Title);
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        var root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        var label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Birdhouse/Features/Builds/Configuration/Editor/BuildConfigurationWindow.uxml");
        var labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Birdhouse/Features/Builds/Configuration/Editor/BuildConfigurationWindow.uss");
        var labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);
    }
}