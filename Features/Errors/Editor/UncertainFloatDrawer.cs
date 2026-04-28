using System.Collections.Generic;
using System.Globalization;
using Birdhouse.Features.Errors;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Features.Errors.Editor
{
    [CustomPropertyDrawer(typeof(UncertainFloat))]
    public class UncertainFloatDrawer
        : PropertyDrawer
    {
        private const float GraphHeight = 50f;
        private const float SettingsHeight = 45f;
        private const float VerticalSpacing = 4f;

        private static Dictionary<string, bool> foldoutStates = new Dictionary<string, bool>();

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight;

            string key = property.propertyPath;
            var isExpanded = foldoutStates.ContainsKey(key) && foldoutStates[key];

            if (isExpanded)
            {
                height += VerticalSpacing;
                height += GraphHeight;
                height += VerticalSpacing;
                height += SettingsHeight;
            }

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var originProp = property.FindPropertyRelative("origin");
            var positiveErrorProp = property.FindPropertyRelative("positiveError");
            var negativeErrorProp = property.FindPropertyRelative("negativeError");
            var isPositivePercentProp = property.FindPropertyRelative("isPositivePercent");
            var isNegativePercentProp = property.FindPropertyRelative("isNegativePercent");
            var settingsProp = property.FindPropertyRelative("errorProviderSettings");

            if (originProp == null || settingsProp == null) return;

            EditorGUI.BeginProperty(position, label, property);

            string key = property.propertyPath;
            var isExpanded = foldoutStates.ContainsKey(key) && foldoutStates[key];

            // Основная строка
            var lineRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            var foldoutRect = new Rect(lineRect.x, lineRect.y, 16, lineRect.height);
            var labelRect = new Rect(lineRect.x + 16, lineRect.y, EditorGUIUtility.labelWidth - 16, lineRect.height);
            var fieldRect = new Rect(lineRect.x + EditorGUIUtility.labelWidth, lineRect.y,
                lineRect.width - EditorGUIUtility.labelWidth, lineRect.height);

            bool newExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, GUIContent.none);
            if (newExpanded != isExpanded) foldoutStates[key] = newExpanded;

            EditorGUI.LabelField(labelRect, label);

            var displayText = GetDisplayText(originProp, positiveErrorProp, negativeErrorProp,
                isPositivePercentProp, isNegativePercentProp);

            string newText = EditorGUI.DelayedTextField(fieldRect, displayText);

            if (newText != displayText)
            {
                if (UncertaintyParser.TryParse(newText, out var origin, out var negativeError, out var positiveError,
                        out var isNegativePercent, out var isPositivePercent))
                {
                    originProp.floatValue = origin;
                    positiveErrorProp.floatValue = positiveError;
                    negativeErrorProp.floatValue = negativeError;
                    isPositivePercentProp.boolValue = isPositivePercent;
                    isNegativePercentProp.boolValue = isNegativePercent;
                    property.serializedObject.ApplyModifiedProperties();
                }
            }

            // Развернутая панель
            if (newExpanded)
            {
                var currentY = position.y + EditorGUIUtility.singleLineHeight + VerticalSpacing;

                // Фон панели
                var panelHeight = GraphHeight + SettingsHeight + VerticalSpacing;
                var panelBgRect = new Rect(position.x, currentY - 2, position.width, panelHeight + 4);
                EditorGUI.DrawRect(panelBgRect, new Color(0.2f, 0.2f, 0.2f));
                Handles.DrawSolidRectangleWithOutline(panelBgRect, Color.clear, new Color(0.3f, 0.3f, 0.3f));

                // График
                var graphRect = new Rect(position.x + 4, currentY, position.width - 8, GraphHeight);
                DrawDistributionGraph(graphRect, settingsProp, positiveErrorProp, negativeErrorProp,
                    originProp, isPositivePercentProp, isNegativePercentProp);
                currentY += GraphHeight + VerticalSpacing;

                // Разделитель
                var separatorRect = new Rect(position.x + 4, currentY, position.width - 8, 1);
                EditorGUI.DrawRect(separatorRect, new Color(0.3f, 0.3f, 0.3f));
                currentY += VerticalSpacing;

                // Настройки
                var settingsRect = new Rect(position.x + 4, currentY, position.width - 8, SettingsHeight);
                DrawApproximatorSettings(settingsRect, settingsProp);
            }

            EditorGUI.EndProperty();
        }

        private void DrawDistributionGraph(Rect rect, SerializedProperty settingsProp,
            SerializedProperty posErrorProp, SerializedProperty negErrorProp, SerializedProperty originProp,
            SerializedProperty posPercentProp, SerializedProperty negPercentProp)
        {
            if (rect.width <= 0 || settingsProp == null) return;

            float origin = originProp.floatValue;
            float posErr = posErrorProp.floatValue;
            float negErr = negErrorProp.floatValue;
            var posPercent = posPercentProp?.boolValue ?? false;
            var negPercent = negPercentProp?.boolValue ?? false;

            // Реальные границы ошибки в значениях
            var negDelta = (negPercent ? origin * negErr / 100f : negErr);
            var posDelta = (posPercent ? origin * posErr / 100f : posErr);

            var minResult = origin - negDelta;
            var maxResult = origin + posDelta;

            if (Mathf.Approximately(minResult, maxResult))
            {
                EditorGUI.LabelField(rect, "No error range", EditorStyles.miniLabel);
                return;
            }

            // Добавляем 10% отступа по краям для лучшей видимости
            var range = maxResult - minResult;
            var padding = range * 0.1f;
            var displayMin = minResult - padding;
            var displayMax = maxResult + padding;

            // Получаем настройки распределения
            var typeProp = settingsProp.FindPropertyRelative("type");
            var sigmaProp = settingsProp.FindPropertyRelative("sigma");
            var lambdaProp = settingsProp.FindPropertyRelative("lambda");
            var peakProp = settingsProp.FindPropertyRelative("peak");
            var curveProp = settingsProp.FindPropertyRelative("curve");

            if (typeProp == null) return;

            var type = (EErrorProvider)typeProp.enumValueIndex;
            var sigma = sigmaProp?.floatValue ?? 0.33f;
            var lambda = lambdaProp?.floatValue ?? 2f;
            var peak = peakProp?.floatValue ?? 0f;
            var curve = curveProp?.animationCurveValue ?? AnimationCurve.Linear(0, 0, 1, 1);

            // Фон графика
            EditorGUI.DrawRect(rect, new Color(0.15f, 0.15f, 0.15f));
            Handles.DrawSolidRectangleWithOutline(rect, Color.clear, new Color(0.35f, 0.35f, 0.35f));

            // Оси
            Color prevColor = Handles.color;
            Handles.color = new Color(0.4f, 0.4f, 0.4f);

            // Ось Y (0)
            var zeroY = rect.y + rect.height;
            Handles.DrawLine(new Vector3(rect.x, zeroY), new Vector3(rect.x + rect.width, zeroY));

            // Ось X (origin)
            var originX = rect.x + (origin - displayMin) / (displayMax - displayMin) * rect.width;
            Handles.color = new Color(0.6f, 0.6f, 0.2f);
            Handles.DrawLine(new Vector3(originX, rect.y), new Vector3(originX, rect.y + rect.height));

            // Сетка 4x2
            Handles.color = new Color(0.3f, 0.3f, 0.3f);

            // Вертикальные линии (4 столбца)
            for (var i = 1; i <= 3; i++)
            {
                var t = i / 4f;
                var x = rect.x + t * rect.width;
                Handles.DrawLine(new Vector3(x, rect.y), new Vector3(x, rect.y + rect.height));
            }

            // Горизонтальные линии (2 строки)
            for (var i = 1; i <= 1; i++)
            {
                var y = rect.y + i * rect.height / 2f;
                Handles.DrawLine(new Vector3(rect.x, y), new Vector3(rect.x + rect.width, y));
            }

            // Кривая распределения
            Handles.color = new Color(0.3f, 0.8f, 0.3f);

            var points = 200;
            var curvePoints = new Vector3[points + 1];

            // Находим максимальное значение PDF в диапазоне
            var maxPdf = 0f;
            var pdfValues = new float[points + 1];

            for (var i = 0; i <= points; i++)
            {
                var t = i / (float)points;
                var value = Mathf.Lerp(displayMin, displayMax, t);

                // Нормализованная ошибка в [-1, 1]
                var normalizedError = GetNormalizedError(value, origin, negDelta, posDelta);

                // PDF от нормализованной ошибки
                var pdf = GetPdfValue(type, normalizedError, sigma, lambda, peak, curve);
                pdfValues[i] = pdf;
                if (pdf > maxPdf) maxPdf = pdf;
            }

            if (maxPdf > 0)
            {
                for (var i = 0; i <= points; i++)
                {
                    var t = i / (float)points;
                    var pdf = pdfValues[i];

                    var screenX = rect.x + t * rect.width;
                    var screenY = rect.y + rect.height * (1f - (pdf / maxPdf));
                    screenY = Mathf.Clamp(screenY, rect.y, rect.y + rect.height);

                    curvePoints[i] = new Vector3(screenX, screenY);
                }

                Handles.DrawPolyLine(curvePoints);
            }

            // Подписи
            var miniLabel = new GUIStyle(EditorStyles.miniLabel);
            miniLabel.normal.textColor = new Color(0.7f, 0.7f, 0.7f);

            // Подписи по оси X (центр, лево, право)
            var centerX = rect.x + (origin - displayMin) / (displayMax - displayMin) * rect.width;
            GUI.Label(new Rect(centerX - 20, rect.y + rect.height - 12, 40, 12),
                FormatValue(origin), miniLabel);
            GUI.Label(new Rect(rect.x - 35, rect.y + rect.height - 12, 40, 12),
                FormatValue(displayMin), miniLabel);
            GUI.Label(new Rect(rect.xMax - 30, rect.y + rect.height - 12, 40, 12),
                FormatValue(displayMax), miniLabel);

            // Подписи по оси Y
            GUI.Label(new Rect(rect.x - 25, rect.y - 6, 25, 12),
                "max", miniLabel);
            GUI.Label(new Rect(rect.x - 20, rect.y + rect.height / 2 - 6, 20, 12),
                "0.5", miniLabel);

            Handles.color = prevColor;
        }

        private float GetNormalizedError(float resultValue, float origin, float negDelta, float posDelta)
        {
            if (resultValue <= origin)
            {
                // Отрицательная ошибка: возвращаем значение от -1 до 0
                var offset = origin - resultValue;
                var normalized = -offset / Mathf.Max(negDelta, 0.0001f);
                return Mathf.Clamp(normalized, -1f, 0f);
            }
            else
            {
                // Положительная ошибка: возвращаем значение от 0 до 1
                var offset = resultValue - origin;
                var normalized = offset / Mathf.Max(posDelta, 0.0001f);
                return Mathf.Clamp(normalized, 0f, 1f);
            }
        }

        private float GetPdfValue(EErrorProvider type, float x, float sigma, float lambda, float peak,
            AnimationCurve curve)
        {
            switch (type)
            {
                case EErrorProvider.Uniform:
                    return Mathf.Abs(x) <= 1f ? 1f : 0f;

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
                    if (curve == null) return 0.5f;

                    // x находится в диапазоне [-1, 1]
                    if (x < 0)
                    {
                        // Отрицательная ошибка: зеркалим кривую
                        // x = 0 → t = 0, x = -1 → t = 1
                        var t = -x; // от 0 до 1
                        return curve.Evaluate(t);
                    }
                    else
                    {
                        // Положительная ошибка: кривая как есть
                        // x = 0 → t = 0, x = 1 → t = 1
                        return curve.Evaluate(x);
                    }

                default:
                    return 1f;
            }
        }

        private string FormatValue(float value)
        {
            return value.ToString("0.##", CultureInfo.InvariantCulture);
        }

        private float GetPositionInRect(float minValue, float maxValue, float value, Rect rect)
        {
            var t = (value - minValue) / (maxValue - minValue);
            return rect.x + t * rect.width;
        }

        private float CalculatePdf(float value, EErrorProvider type, float origin,
            float sigma, float lambda, float peak, AnimationCurve curve)
        {
            switch (type)
            {
                case EErrorProvider.Uniform:
                    return 1f;

                case EErrorProvider.Normal:
                    // Нормализуем относительно origin, масштаб sigma
                    var x = (value - origin) / sigma;
                    return Mathf.Exp(-x * x / 2f);

                case EErrorProvider.Triangle:
                    // Треугольное распределение на интервале [origin-1, origin+1] с пиком в origin+peak
                    var minT = origin - 1f;
                    var maxT = origin + 1f;
                    if (value < minT || value > maxT) return 0f;
                    var peakPosT = origin + peak;
                    if (value <= peakPosT)
                        return (value - minT) / (peakPosT - minT);
                    else
                        return (maxT - value) / (maxT - peakPosT);

                case EErrorProvider.Exponential:
                    var delta = Mathf.Abs(value - origin);
                    return Mathf.Exp(-delta * lambda);

                case EErrorProvider.Custom:
                    // Пользовательская кривая: X от origin-1 до origin+1, Y = curve.Evaluate(x)
                    var t = (value - origin + 1f) / 2f;
                    t = Mathf.Clamp01(t);
                    var curveValue = curve?.Evaluate(t) ?? 0.5f;
                    // curveValue уже в диапазоне [0,1] (вероятность)
                    return curveValue;

                default:
                    return 1f;
            }
        }

        private float CalculateMaxPdfInRange(EErrorProvider type, float min, float max, float origin, float sigma,
            float lambda, float peak, AnimationCurve curve)
        {
            switch (type)
            {
                case EErrorProvider.Uniform:
                    return 1f;

                case EErrorProvider.Normal:
                    return 1f; // максимум в origin

                case EErrorProvider.Triangle:
                    return 1f; // максимум в peak

                case EErrorProvider.Exponential:
                    return 1f; // максимум в origin

                case EErrorProvider.Custom:
                    // Ищем максимум кривой в интервале [0,1]
                    var maxCurve = 0f;
                    for (float t = 0; t <= 1f; t += 0.05f)
                    {
                        var val = curve?.Evaluate(t) ?? 0f;
                        if (val > maxCurve) maxCurve = val;
                    }

                    return maxCurve > 0 ? maxCurve : 1f;

                default:
                    return 1f;
            }
        }

        private void DrawApproximatorSettings(Rect rect, SerializedProperty settingsProp)
        {
            if (settingsProp == null) return;

            var typeProp = settingsProp.FindPropertyRelative("type");
            var sigmaProp = settingsProp.FindPropertyRelative("sigma");
            var lambdaProp = settingsProp.FindPropertyRelative("lambda");
            var peakProp = settingsProp.FindPropertyRelative("peak");
            var curveProp = settingsProp.FindPropertyRelative("curve");

            if (typeProp == null) return;

            var labelWidth = 40f;
            var spacing = 5f;

            // Лейбл
            var labelRect = new Rect(rect.x, rect.y + 5, labelWidth, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(labelRect, "Dist:", EditorStyles.miniLabel);

            // Dropdown
            var fieldStart = rect.x + labelWidth + spacing;
            var fieldWidth = 90f;
            var typeRect = new Rect(fieldStart, rect.y + 5, fieldWidth, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(typeRect, typeProp, GUIContent.none);

            var type = (EErrorProvider)typeProp.enumValueIndex;

            // Параметры
            var paramStart = typeRect.xMax + spacing;
            var paramWidth = rect.width - (paramStart - rect.x) - 55;
            var valueRect = new Rect(paramStart, rect.y + 5, paramWidth, EditorGUIUtility.singleLineHeight);

            switch (type)
            {
                case EErrorProvider.Normal:
                    EditorGUI.Slider(valueRect, sigmaProp, 0.1f, 1f, new GUIContent("σ"));
                    break;

                case EErrorProvider.Exponential:
                    EditorGUI.Slider(valueRect, lambdaProp, 0.5f, 5f, new GUIContent("λ"));
                    break;

                case EErrorProvider.Triangle:
                    EditorGUI.Slider(valueRect, peakProp, -1f, 1f, new GUIContent("peak"));
                    break;

                case EErrorProvider.Custom:
                    EditorGUI.PropertyField(valueRect, curveProp, GUIContent.none);
                    break;

                default:
                    EditorGUI.LabelField(valueRect, "No parameters", EditorStyles.miniLabel);
                    break;
            }

            // Кнопка Reset
            var resetRect = new Rect(rect.x + rect.width - 48, rect.y + 5, 45, EditorGUIUtility.singleLineHeight);
            if (GUI.Button(resetRect, "Reset", EditorStyles.miniButton))
            {
                switch (type)
                {
                    case EErrorProvider.Normal:
                        if (sigmaProp != null) sigmaProp.floatValue = 0.33f;
                        break;
                    case EErrorProvider.Exponential:
                        if (lambdaProp != null) lambdaProp.floatValue = 2f;
                        break;
                    case EErrorProvider.Triangle:
                        if (peakProp != null) peakProp.floatValue = 0f;
                        break;
                    case EErrorProvider.Custom:
                        if (curveProp != null) curveProp.animationCurveValue = AnimationCurve.Linear(0, 0, 1, 1);
                        break;
                }

                settingsProp.serializedObject?.ApplyModifiedProperties();
            }
        }


        private float GetMaxPdfValue(EErrorProvider type, float sigma, float lambda, float peak)
            => type switch
            {
                EErrorProvider.Normal => 1f,
                EErrorProvider.Triangle => 1f,
                EErrorProvider.Exponential => 1f,
                EErrorProvider.Custom => 1f,
                _ => 0.5f
            };

        private string GetDisplayText(SerializedProperty origin, SerializedProperty positiveError,
            SerializedProperty negativeError, SerializedProperty positiveIsPercent,
            SerializedProperty negativeIsPercent)
        {
            float originVal = origin.floatValue;
            float posErr = positiveError.floatValue;
            float negErr = negativeError.floatValue;
            bool posPercent = positiveIsPercent.boolValue;
            bool negPercent = negativeIsPercent.boolValue;

            if (posErr == 0 && negErr == 0) return originVal.ToString(CultureInfo.InvariantCulture);

            if (Mathf.Approximately(posErr, negErr) && posPercent == negPercent)
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
