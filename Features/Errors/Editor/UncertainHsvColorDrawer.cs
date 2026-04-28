using UnityEditor;
using UnityEngine;

namespace Birdhouse.Features.Errors.Editor
{
    [CustomPropertyDrawer(typeof(UncertainHsvColor))]
    public class UncertainHsvColorDrawer : PropertyDrawer
    {
        private const float PreviewSpacing = 4f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            => EditorGUI.GetPropertyHeight(property, label, true) + PreviewSpacing + UncertainColorPreviewUtility.PreviewHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            float defH = EditorGUI.GetPropertyHeight(property, label, true);
            Rect defRect = new Rect(position.x, position.y, position.width, defH);
            EditorGUI.PropertyField(defRect, property, label, true);

            Rect previewRect = new Rect(position.x, position.y + defH + PreviewSpacing, position.width, UncertainColorPreviewUtility.PreviewHeight);

            var h = ExtractChannel(property.FindPropertyRelative("h"));
            var s = ExtractChannel(property.FindPropertyRelative("s"));
            var v = ExtractChannel(property.FindPropertyRelative("v"));

            // Для HSV корректнее интерполировать в HSV-пространстве
            Color origin = UncertainColorPreviewUtility.LerpHsvColor(
                Color.HSVToRGB(h.origin, s.origin, v.origin),
                Color.HSVToRGB(h.origin, s.origin, v.origin), 0.5f); // placeholder, ниже пересчитаем

            // Вычисляем точные цвета Min, Origin, Max
            Color cMin = Color.HSVToRGB(h.min, s.min, v.min);
            Color cOrig = Color.HSVToRGB(h.origin, s.origin, v.origin);
            Color cMax = Color.HSVToRGB(h.max, s.max, v.max);

            UncertainColorPreviewUtility.DrawDeterministicGradient(previewRect, cMin, cOrig, cMax);
            EditorGUI.EndProperty();
        }

        private static (float origin, float min, float max) ExtractChannel(SerializedProperty p)
        {
            if (p == null) return (0f, 0f, 0f);
            float o = p.FindPropertyRelative("origin").floatValue;
            float neg = p.FindPropertyRelative("negativeError").floatValue;
            float pos = p.FindPropertyRelative("positiveError").floatValue;
            bool nPct = p.FindPropertyRelative("isNegativePercent").boolValue;
            bool pPct = p.FindPropertyRelative("isPositivePercent").boolValue;

            float nAmt = nPct ? o * neg / 100f : neg;
            float pAmt = pPct ? o * pos / 100f : pos;
            return (o, o - nAmt, o + pAmt);
        }
    }
}