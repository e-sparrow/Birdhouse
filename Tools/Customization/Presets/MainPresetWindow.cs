using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESparrow.Utils.Nodes.Splitters;
using ESparrow.Utils.Tools.Customization.Presets.Interfaces;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ESparrow.Utils.Tools.Customization.Presets
{
    /// <summary>
    /// Window to find presets of all the types.
    /// Same - to correct values of presets and save it to files.
    /// </summary>
    public class MainPresetWindow : EditorWindow
    {
        private const string Path = @"Window/ESparrow/Utils/Presets/Show Window";
        private const string Title = "Presets";

        private static readonly IPresetManager<string> PresetManager = new PresetManager<string>();
        
        private VisualElement _currentPreset;
        private VisualElement _currentAsset;
        
        [MenuItem(Path)]
        private static void ShowFromMenu()
        {
            var window = GetWindow<MainPresetWindow>();
            window.titleContent = new GUIContent(Title);
        }

        [MenuItem("Debug/ESparrow/CreatePreset")]
        private static void DebugCreate()
        {
            throw new NotImplementedException();
            // var preset = new PresetAsset<string>("Example", new Dictionary<Type, IDictionary<string, object>>());
            // PresetManager.AddPreset(preset);
        }

        public void CreateGUI()
        {
            // Get a list of all sprites in the project
            var allObjectGuids = AssetDatabase.FindAssets("t:Sprite");
            var allObjects = new List<Sprite>();
            foreach (var guid in allObjectGuids)
            {
                allObjects.Add(AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            
            //Resources.FindObjectsOfTypeAll<>()

            // Create a two-pane view with the left pane being fixed with
            var vertical = new TwoPaneSplitView(0, 240, TwoPaneSplitViewOrientation.Vertical);
            
            rootVisualElement.Add(vertical);

            var topHorizontal = new TwoPaneSplitView(0, 240, TwoPaneSplitViewOrientation.Horizontal);
            var bottomHorizontal = new TwoPaneSplitView(0, 240, TwoPaneSplitViewOrientation.Horizontal);

            // Add the panel to the visual tree by adding it as a child to the root element
            vertical.Add(topHorizontal);
            vertical.Add(bottomHorizontal);

            var assets = new ListView();
            var types = new ListView();
            _currentAsset = types;
            InitAssets();
            topHorizontal.Add(assets);
            topHorizontal.Add(types);

            // A TwoPaneSplitView always needs exactly two child elements
            var presets = new ListView();
            bottomHorizontal.Add(presets);
            _currentPreset = new VisualElement();
            bottomHorizontal.Add(_currentPreset);
            
            InitPresets();

            void InitAssets()
            {
                var assetObjects = PresetManager.LoadPresets().ToArray();
                assets = new ListView
                { 
                    makeItem = () =>
                    {
                        var label = new Label();
                        label.style.alignContent = Align.Center;
                        return label;
                    },
                
                    bindItem = (item, index) =>
                    {
                        var value = (Label) item;
                        // value.text =  assetObjects[index];
                    },
                    
                    itemsSource = assetObjects
                };

                assets.onSelectionChange += SelectAsset;

                void SelectAsset(IEnumerable<object> targetAssets)
                {
                    _currentAsset.Clear();

                    var asset = targetAssets.First() as PresetAsset<string>;
                    if (asset == null)
                        return;

                    var presetTypes = asset.GetPresets().GroupBy(value => value.Type);
                    types.makeItem = () =>
                    {
                        var tt = new Button();
                        return tt;
                    };

                    types.bindItem = (item, index) => ((Button) item).text = index.ToString();
                    var source = presetTypes.Select(value => value.Key).ToList();
                    types.itemsSource = source;

                    types.onSelectionChange += SelectType;

                    _currentAsset = types;

                    void SelectType(IEnumerable<object> targetTypes)
                    {
                        var type = targetTypes.First() as Type;
                    }
                }
            }

            void InitPresets()
            {
                presets.makeItem = () => new Label();
                presets.bindItem = (item, index) => { (item as Label).text = allObjects[index].name; };
                presets.itemsSource = allObjects;
                presets.onSelectionChange += Select;
                
                void Select(IEnumerable<object> selectedItems)
                {
                    // Clear all previous content from the pane
                    _currentPreset.Clear();

                    // Get the selected sprite
                    var selectedSprite = selectedItems.First() as Sprite;
                    if (selectedSprite == null)
                        return;

                    // Add a new Image control and display the sprite
                    var spriteImage = new Image();
                    spriteImage.scaleMode = ScaleMode.ScaleToFit;
                    spriteImage.image = selectedSprite.texture;

                    // Add the Image control to the right-hand pane
                    _currentPreset.Add(spriteImage);
                }
            }
        }

        private class ListViewController<T> where T : VisualElement
        {
            public ListViewController(ListView listView, Func<T> create, Action<T, int> bind)
            {
                _listView = listView;
                _listView.makeItem = create;
                _listView.bindItem = Bind;
                _listView.onSelectionChange += Select;

                void Bind(VisualElement value, int index)
                {
                    var item = (T) value;
                    bind.Invoke(item, index);
                }
            }

            public event Action<T> OnSelect = _ => { };

            private readonly ListView _listView;

            public void Set(IEnumerable<T> enumerable)
            {
                _listView.itemsSource = enumerable as IList;
            }

            private void Select(IEnumerable<object> element)
            {
                var item = (T) element.First();
                OnSelect.Invoke(item);
            }
        }
    }
}