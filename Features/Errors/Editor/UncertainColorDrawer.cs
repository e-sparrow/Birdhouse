using UnityEditor;
using UnityEngine;

namespace Birdhouse.Features.Errors.Editor
{
    [CustomPropertyDrawer(typeof(UncertainColor))]
    public class UncertainColorDrawer : PropertyDrawer
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

            // Вычисляем Min, Origin, Max в RGB
            var r = ExtractChannel(property.FindPropertyRelative("r"));
            var g = ExtractChannel(property.FindPropertyRelative("g"));
            var b = ExtractChannel(property.FindPropertyRelative("b"));
            var a = ExtractChannel(property.FindPropertyRelative("a"));

            Color origin = new Color(r.origin, g.origin, b.origin, a.origin);
            Color min = new Color(r.min, g.min, b.min, a.min);
            Color max = new Color(r.max, g.max, b.max, a.max);

            UncertainColorPreviewUtility.DrawDeterministicGradient(previewRect, min, origin, max);
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