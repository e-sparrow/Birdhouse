using UnityEditor;
using UnityEngine;
using System.Globalization;
using System.Collections.Generic;

namespace Birdhouse.Features.Errors.Editor
{
    [CustomPropertyDrawer(typeof(UncertainInt))]
    public class UncertainIntDrawer : PropertyDrawer
    {
        private const float GraphHeight = 60f;
        private const float SettingsHeight = 45f;
        
        private static Dictionary<string, bool> _foldoutStates = new Dictionary<string, bool>();
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = EditorGUIUtility.singleLineHeight;
            
            var key = property.propertyPath;
            var isExpanded = _foldoutStates.ContainsKey(key) && _foldoutStates[key];
            
            if (isExpanded)
            {
                height += 5;
                height += GraphHeight;
                height += SettingsHeight;
            }
            
            return height;
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var originProperty = property.FindPropertyRelative("origin");
            var positiveErrorProperty = property.FindPropertyRelative("positiveError");
            var negativeErrorProperty = property.FindPropertyRelative("negativeError");
            var isPositivePercentProperty = property.FindPropertyRelative("positiveIsPercent");
            var isNegativePercentProperty = property.FindPropertyRelative("negativeIsPercent");
            var approximatorTypeProperty = property.FindPropertyRelative("approximatorType");
            var sigmaProperty = property.FindPropertyRelative("sigma");
            var lambdaProperty = property.FindPropertyRelative("lambda");
            var peakProperty = property.FindPropertyRelative("peak");
            var curveProperty = property.FindPropertyRelative("curve");
            
            if (originProperty == null) return;
            
            EditorGUI.BeginProperty(position, label, property);
            
            var key = property.propertyPath;
            var isExpanded = _foldoutStates.ContainsKey(key) && _foldoutStates[key];
            
            // Основная строка
            var lineRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            
            var foldoutRect = new Rect(lineRect.x, lineRect.y, 16, lineRect.height);
            var labelRect = new Rect(lineRect.x + 16, lineRect.y, EditorGUIUtility.labelWidth - 16, lineRect.height);
            var fieldRect = new Rect(lineRect.x + EditorGUIUtility.labelWidth, lineRect.y, 
                lineRect.width - EditorGUIUtility.labelWidth, lineRect.height);
            
            // Foldout
            var newExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, GUIContent.none);
            if (newExpanded != isExpanded)
            {
                _foldoutStates[key] = newExpanded;
            }
            
            // Лейбл
            EditorGUI.LabelField(labelRect, label);
            
            // Поле ввода
            var displayText = GetDisplayText(originProperty, positiveErrorProperty, negativeErrorProperty, 
                isPositivePercentProperty, isNegativePercentProperty);
            
            var newText = EditorGUI.DelayedTextField(fieldRect, displayText);
            
            if (newText != displayText)
            {
                if (UncertaintyParser.TryParseInt(newText, out var origin, out var negativeError, out var positiveError, out var isNegativePercent, out var isPositivePercent))
                {
                    originProperty.intValue = origin;
                    positiveErrorProperty.intValue = positiveError;
                    negativeErrorProperty.intValue = negativeError;
                    isPositivePercentProperty.boolValue = isPositivePercent;
                    isNegativePercentProperty.boolValue = isNegativePercent;
                    property.serializedObject.ApplyModifiedProperties();
                }
            }
            
            // Развернутая панель
            if (newExpanded)
            {
                var panelRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, 
                    position.width, GraphHeight + SettingsHeight);
                
                DrawExpandedPanel(panelRect, approximatorTypeProperty, sigmaProperty, lambdaProperty, 
                    peakProperty, curveProperty, positiveErrorProperty, negativeErrorProperty, originProperty);
            }
            
            EditorGUI.EndProperty();
        }
        
        private void DrawExpandedPanel(Rect rect, SerializedProperty approximatorType, 
            SerializedProperty sigma, SerializedProperty lambda, SerializedProperty peak, 
            SerializedProperty curve, SerializedProperty posError, SerializedProperty negError, 
            SerializedProperty originProp)
        {
            var backgroundColor = new Color(0.24f, 0.24f, 0.24f);
            EditorGUI.DrawRect(rect, backgroundColor);
            Handles.DrawSolidRectangleWithOutline(rect, Color.clear, new Color(0.3f, 0.3f, 0.3f));
            
            // График
            var graphRect = new Rect(rect.x + 5, rect.y + 5, rect.width - 10, GraphHeight);
            DrawDistributionGraph(graphRect, approximatorType, sigma, lambda, peak, curve, posError, negError, originProp);
            
            // Настройки
            var settingsRect = new Rect(rect.x + 5, rect.y + GraphHeight + 5, rect.width - 10, SettingsHeight);
            DrawApproximatorSettings(settingsRect, approximatorType, sigma, lambda, peak, curve);
        }
        
        private void DrawDistributionGraph(Rect rect, SerializedProperty approximatorType,
            SerializedProperty sigma, SerializedProperty lambda, SerializedProperty peak,
            SerializedProperty curve, SerializedProperty posError, SerializedProperty negError,
            SerializedProperty originProp)
        {
            if (rect.width <= 0) return;
            
            EditorGUI.DrawRect(rect, new Color(0.15f, 0.15f, 0.15f));
            
            var prevColor = Handles.color;
            Handles.color = new Color(0.35f, 0.35f, 0.35f);
            
            // Оси
            var zeroY = rect.y + rect.height / 2;
            Handles.DrawLine(new Vector3(rect.x, zeroY), new Vector3(rect.x + rect.width, zeroY));
            Handles.DrawLine(new Vector3(rect.x, rect.y), new Vector3(rect.x, rect.y + rect.height));
            
            // Сетка
            var y25 = rect.y + rect.height * 0.25f;
            var y75 = rect.y + rect.height * 0.75f;
            Handles.DrawLine(new Vector3(rect.x, y25), new Vector3(rect.x + rect.width, y25));
            Handles.DrawLine(new Vector3(rect.x, y75), new Vector3(rect.x + rect.width, y75));
            
            for (var x = 0.25f; x <= 0.75f; x += 0.25f)
            {
                var pixelX = rect.x + x * rect.width;
                Handles.DrawLine(new Vector3(pixelX, rect.y), new Vector3(pixelX, rect.y + rect.height));
            }
            
            // Кривая распределения
            Handles.color = new Color(0.2f, 0.8f, 0.2f);
            
            var type = (EErrorProvider)approximatorType.enumValueIndex;
            var sigmaVal = sigma.floatValue;
            var lambdaVal = lambda.floatValue;
            var peakVal = peak.floatValue;
            var curveVal = curve.animationCurveValue;
            
            var points = 100;
            var curvePoints = new Vector3[points];
            
            var maxPdf = GetMaxPdfValue(type, sigmaVal, lambdaVal, peakVal);
            
            for (var i = 0; i < points; i++)
            {
                var x = i / (float)(points - 1);
                var normalizedValue = x * 2f - 1f;
                
                var pdf = GetPdfValue(type, normalizedValue, sigmaVal, lambdaVal, peakVal, curveVal);
                var normalizedPdf = pdf / maxPdf;
                
                var screenX = rect.x + x * rect.width;
                var screenY = zeroY - normalizedPdf * (rect.height / 2);
                screenY = Mathf.Clamp(screenY, rect.y, rect.y + rect.height);
                
                curvePoints[i] = new Vector3(screenX, screenY);
            }
            
            Handles.DrawPolyLine(curvePoints);
            
            // Подписи
            GUI.Label(new Rect(rect.x - 12, zeroY - 6, 20, 12), "0", EditorStyles.miniLabel);
            GUI.Label(new Rect(rect.xMax - 8, rect.yMax - 14, 20, 12), "1", EditorStyles.miniLabel);
            GUI.Label(new Rect(rect.xMax - 8, rect.y - 10, 20, 12), "-1", EditorStyles.miniLabel);
            
            // Дискретные точки для int
            var origin = originProp.intValue;
            var posErr = posError.intValue;
            var negErr = negError.intValue;
            var posPercent = false;
            var negPercent = false;
            
            Handles.color = new Color(0.8f, 0.5f, 0.2f);
            for (var offset = -negErr; offset <= posErr; offset++)
            {
                if (offset == 0) continue;
                float normalizedOffset = offset / Mathf.Max(posErr, negErr);
                var screenX = rect.x + (normalizedOffset + 1f) / 2f * rect.width;
                Handles.DrawSolidDisc(new Vector3(screenX, zeroY), Vector3.forward, 2f);
            }
            
            Handles.color = prevColor;
        }
        
        private void DrawApproximatorSettings(Rect rect, SerializedProperty approximatorType,
            SerializedProperty sigma, SerializedProperty lambda, SerializedProperty peak, SerializedProperty curve)
        {
            var fieldWidth = (rect.width - 60) / 3f;
            var spacing = 5f;
            
            var typeRect = new Rect(rect.x, rect.y, fieldWidth, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(typeRect, approximatorType, GUIContent.none);
            
            var type = (EErrorProvider)approximatorType.enumValueIndex;
            var valueRect = new Rect(typeRect.xMax + spacing, rect.y, fieldWidth, EditorGUIUtility.singleLineHeight);
            
            switch (type)
            {
                case EErrorProvider.Normal:
                    EditorGUI.Slider(valueRect, sigma, 0.1f, 1f, new GUIContent("σ"));
                    break;
                    
                case EErrorProvider.Exponential:
                    EditorGUI.Slider(valueRect, lambda, 0.5f, 5f, new GUIContent("λ"));
                    break;
                    
                case EErrorProvider.Triangle:
                    EditorGUI.Slider(valueRect, peak, -1f, 1f, new GUIContent("peak"));
                    break;
                    
                case EErrorProvider.Custom:
                    valueRect.width = rect.width - typeRect.width - spacing - 60;
                    EditorGUI.PropertyField(valueRect, curve, GUIContent.none);
                    break;
                    
                default:
                    EditorGUI.LabelField(valueRect, "No parameters");
                    break;
            }
            
            var resetRect = new Rect(valueRect.xMax + spacing, rect.y, 55, EditorGUIUtility.singleLineHeight);
            if (GUI.Button(resetRect, "Reset"))
            {
                ResetSettings(type, sigma, lambda, peak, curve);
            }
        }
        
        private void ResetSettings(EErrorProvider type, SerializedProperty sigma, 
            SerializedProperty lambda, SerializedProperty peak, SerializedProperty curve)
        {
            switch (type)
            {
                case EErrorProvider.Normal:
                    sigma.floatValue = 0.33f;
                    break;
                case EErrorProvider.Exponential:
                    lambda.floatValue = 2f;
                    break;
                case EErrorProvider.Triangle:
                    peak.floatValue = 0f;
                    break;
                case EErrorProvider.Custom:
                    curve.animationCurveValue = AnimationCurve.Linear(0, 0, 1, 1);
                    break;
            }
            sigma.serializedObject.ApplyModifiedProperties();
        }
        
        private float GetPdfValue(EErrorProvider type, float x, float sigma, float lambda, float peak, AnimationCurve curve)
        {
            switch (type)
            {
                case EErrorProvider.Uniform:
                    return Mathf.Abs(x) <= 1f ? 0.5f : 0f;
                case EErrorProvider.Normal:
                    return Mathf.Exp(-Mathf.Pow(x / sigma, 2) / 2f);
                case EErrorProvider.Triangle:
                    if (x <= peak)
                        return (x + 1f) / (peak + 1f);
                    else
                        return (1f - x) / (1f - peak);
                case EErrorProvider.Exponential:
                    return Mathf.Exp(-Mathf.Abs(x) * lambda);
                case EErrorProvider.Custom:
                    var t = (x + 1f) / 2f;
                    return curve?.Evaluate(t) ?? 0.5f;
                default:
                    return 0.5f;
            }
        }
        
        private float GetMaxPdfValue(EErrorProvider type, float sigma, float lambda, float peak)
        {
            return type switch
            {
                EErrorProvider.Normal => 1f,
                EErrorProvider.Triangle => 1f,
                EErrorProvider.Exponential => 1f,
                EErrorProvider.Custom => 1f,
                _ => 0.5f
            };
        }
        
        private string GetDisplayText(SerializedProperty origin, SerializedProperty positiveError, 
            SerializedProperty negativeError, SerializedProperty positiveIsPercent, SerializedProperty negativeIsPercent)
        {
            var originVal = origin.intValue;
            var posErr = positiveError.intValue;
            var negErr = negativeError.intValue;
            var posPercent = positiveIsPercent.boolValue;
            var negPercent = negativeIsPercent.boolValue;
            
            if (posErr == 0 && negErr == 0)
                return originVal.ToString();
            
            if (posErr == negErr && posPercent == negPercent)
            {
                var result = $"{originVal} ± {posErr}";
                if (posPercent) result += "%";
                return result;
            }
            
            var posStr = posPercent ? $"{posErr}%" : posErr.ToString();
            var negStr = negPercent ? $"{negErr}%" : negErr.ToString();
            
            return $"{originVal} +{posStr}/-{negStr}";
        }
    }
}