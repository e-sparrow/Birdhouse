using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace Birdhouse.Tools.Customization.TypeSerialization
{
    public sealed class CompositeTypeEditor 
        : VisualElement
    {
        private object _currentValue;
        private Type _currentType;
        private readonly List<VisualElement> _fieldEditors = new List<VisualElement>();
        
        public event Action<object> OnValueChanged = _ => { };

        public void SetType(Type type, object initialValue = null)
        {
            _currentType = type;
            _fieldEditors.Clear();
            Clear();

            if (type == null) return;

            // Для примитивных типов используем стандартные поля
            if (IsPrimitiveType(type))
            {
                CreatePrimitiveField(type, initialValue);
            }
            else
            {
                // Для составных типов создаем поля для каждого свойства
                CreateCompositeFields(type, initialValue);
            }
        }

        private bool IsPrimitiveType(Type type)
        {
            return type.IsPrimitive || 
                   type == typeof(string) || 
                   type == typeof(Vector2) || 
                   type == typeof(Vector3) ||
                   type.IsEnum;
        }

        private void CreatePrimitiveField(Type type, object initialValue)
        {
            VisualElement field = null;

            if (type == typeof(string))
            {
                var textField = new TextField(type.Name);
                textField.value = initialValue?.ToString() ?? "";
                textField.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = textField;
            }
            else if (type == typeof(int))
            {
                var intField = new IntegerField(type.Name);
                intField.value = initialValue != null ? (int)initialValue : 0;
                intField.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = intField;
            }
            else if (type == typeof(float))
            {
                var floatField = new FloatField(type.Name);
                floatField.value = initialValue != null ? (float)initialValue : 0f;
                floatField.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = floatField;
            }
            else if (type == typeof(bool))
            {
                var toggle = new Toggle(type.Name);
                toggle.value = initialValue != null && (bool)initialValue;
                toggle.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = toggle;
            }
            else if (type == typeof(Vector2))
            {
                var vectorField = new Vector2Field(type.Name);
                vectorField.value = initialValue != null ? (Vector2)initialValue : Vector2.zero;
                vectorField.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = vectorField;
            }
            else if (type == typeof(Vector3))
            {
                var vectorField = new Vector3Field(type.Name);
                vectorField.value = initialValue != null ? (Vector3)initialValue : Vector3.zero;
                vectorField.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = vectorField;
            }
            else if (type.IsEnum)
            {
                var enumField = new EnumField(type.Name, (Enum)(initialValue ?? Activator.CreateInstance(type)));
                enumField.RegisterValueChangedCallback(evt => 
                {
                    _currentValue = evt.newValue;
                    OnValueChanged?.Invoke(_currentValue);
                });
                field = enumField;
            }

            if (field != null)
            {
                Add(field);
                _fieldEditors.Add(field);
            }
        }

        private void CreateCompositeFields(Type type, object initialValue)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .Where(p => p.CanRead && p.CanWrite)
                                .ToArray();

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                            .ToArray();

            if (properties.Length == 0 && fields.Length == 0)
            {
                // Если нет публичных полей/свойств, показываем JSON редактор
                CreateJsonEditor(type, initialValue);
                return;
            }

            // Создаем контейнер для составного типа
            var foldout = new Foldout { text = type.Name, value = true };
            Add(foldout);

            // Создаем поля для свойств
            foreach (var property in properties)
            {
                if (!IsSupportedType(property.PropertyType)) continue;

                var propertyValue = initialValue != null ? property.GetValue(initialValue) : GetDefaultValue(property.PropertyType);
                CreateFieldForMember(foldout, property.Name, property.PropertyType, propertyValue, 
                    (obj, value) => property.SetValue(obj, value));
            }

            // Создаем поля для полей
            foreach (var field in fields)
            {
                if (!IsSupportedType(field.FieldType)) continue;

                var fieldValue = initialValue != null ? field.GetValue(initialValue) : GetDefaultValue(field.FieldType);
                CreateFieldForMember(foldout, field.Name, field.FieldType, fieldValue,
                    (obj, value) => field.SetValue(obj, value));
            }
        }

        private void CreateFieldForMember(VisualElement parent, string memberName, Type memberType, object initialValue, Action<object, object> setter)
        {
            if (IsPrimitiveType(memberType))
            {
                var container = new VisualElement();
                container.style.flexDirection = FlexDirection.Row;
                container.style.marginBottom = 5;

                var label = new Label(memberName);
                label.style.minWidth = 100;
                label.style.unityTextAlign = TextAnchor.MiddleLeft;
                container.Add(label);

                VisualElement fieldEditor = CreatePrimitiveFieldEditor(memberType, initialValue, value => 
                {
                    if (_currentValue == null)
                        _currentValue = Activator.CreateInstance(_currentType);
                    
                    setter(_currentValue, value);
                    OnValueChanged?.Invoke(_currentValue);
                });

                if (fieldEditor != null)
                {
                    fieldEditor.style.flexGrow = 1;
                    container.Add(fieldEditor);
                    parent.Add(container);
                    _fieldEditors.Add(container);
                }
            }
            else
            {
                // Рекурсивно создаем редактор для вложенных объектов
                var nestedEditor = new CompositeTypeEditor();
                nestedEditor.SetType(memberType, initialValue);
                nestedEditor.OnValueChanged += value => 
                {
                    if (_currentValue == null)
                        _currentValue = Activator.CreateInstance(_currentType);
                    
                    setter(_currentValue, value);
                    OnValueChanged?.Invoke(_currentValue);
                };

                var foldout = new Foldout { text = memberName };
                foldout.Add(nestedEditor);
                parent.Add(foldout);
                _fieldEditors.Add(foldout);
            }
        }

        private VisualElement CreatePrimitiveFieldEditor(Type type, object initialValue, Action<object> onValueChanged)
        {
            if (type == typeof(string))
            {
                var field = new TextField();
                field.value = initialValue?.ToString() ?? "";
                field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
                return field;
            }
            else if (type == typeof(int))
            {
                var field = new IntegerField();
                field.value = initialValue != null ? (int)initialValue : 0;
                field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
                return field;
            }
            else if (type == typeof(float))
            {
                var field = new FloatField();
                field.value = initialValue != null ? (float)initialValue : 0f;
                field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
                return field;
            }
            else if (type == typeof(bool))
            {
                var field = new Toggle();
                field.value = initialValue != null && (bool)initialValue;
                field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
                return field;
            }
            else if (type.IsEnum)
            {
                var field = new EnumField((Enum)(initialValue ?? Activator.CreateInstance(type)));
                field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
                return field;
            }

            return null;
        }

        private void CreateJsonEditor(Type type, object initialValue)
        {
            var jsonField = new TextField("JSON Data");
            jsonField.multiline = true;
            jsonField.style.height = 100;
            
            try
            {
                var json = initialValue != null ? JsonUtility.ToJson(initialValue, true) : "{}";
                jsonField.value = json;
            }
            catch
            {
                jsonField.value = "{}";
            }

            jsonField.RegisterValueChangedCallback(evt =>
            {
                try
                {
                    _currentValue = JsonUtility.FromJson(evt.newValue, type);
                    OnValueChanged?.Invoke(_currentValue);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to parse JSON: {ex.Message}");
                }
            });

            Add(jsonField);
            _fieldEditors.Add(jsonField);
        }

        private bool IsSupportedType(Type type)
        {
            return type.IsPrimitive || 
                   type == typeof(string) || 
                   type == typeof(Vector2) || 
                   type == typeof(Vector3) ||
                   type.IsEnum ||
                   (type.IsClass && !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null);
        }

        private object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public object GetValue()
        {
            return _currentValue;
        }
    }
}