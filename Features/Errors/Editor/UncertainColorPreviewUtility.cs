using System;
using UnityEngine;
using UnityEditor;

namespace Birdhouse.Features.Errors.Editor
{
    public static class UncertainColorPreviewUtility
    {
        public const float PreviewHeight = 24f;

        /// <summary>
        /// Рисует детерминированный градиент: Min → Origin → Max.
        /// Никакого рандома. Чистая визуализация диапазона.
        /// </summary>
        public static void DrawDeterministicGradient(Rect rect, Color minColor, Color originColor, Color maxColor)
        {
            if (rect.width <= 2f) return;

            // Фон и рамка
            EditorGUI.DrawRect(rect, new Color(0.15f, 0.15f, 0.15f));
            Handles.DrawSolidRectangleWithOutline(rect, Color.clear, new Color(0.35f, 0.35f, 0.35f));

            float halfWidth = rect.width * 0.5f;
            int steps = Mathf.CeilToInt(rect.width);

            // Левая половина: Min -> Origin
            for (int x = 0; x < steps * 0.5f; x++)
            {
                float t = (x / halfWidth);
                Color col = Color.Lerp(minColor, originColor, t);
                EditorGUI.DrawRect(new Rect(rect.x + x, rect.y, 1f, rect.height), col);
            }

            // Правая половина: Origin -> Max
            for (int x = 0; x < steps * 0.5f; x++)
            {
                float t = (x / halfWidth);
                Color col = Color.Lerp(originColor, maxColor, t);
                EditorGUI.DrawRect(new Rect(rect.x + halfWidth + x, rect.y, 1f, rect.height), col);
            }

            // Маркер Origin
            float originX = rect.x + halfWidth;
            Handles.color = new Color(1f, 1f, 0.5f, 0.9f);
            Handles.DrawLine(new Vector3(originX, rect.y), new Vector3(originX, rect.y + rect.height));

            // Подписи
            var style = new GUIStyle(EditorStyles.miniLabel) { normal = { textColor = new Color(0.8f, 0.8f, 0.8f) } };
            GUI.Label(new Rect(rect.x + 4, rect.y + 2, 30, rect.height - 4), "Min", style);
            GUI.Label(new Rect(originX - 16, rect.y + 2, 32, rect.height - 4), "Origin", style);
            GUI.Label(new Rect(rect.xMax - 34, rect.y + 2, 34, rect.height - 4), "Max", style);
        }

        /// <summary>
        /// Безопасная интерполяция цветов с учётом цикличности Hue (для HSV).
        /// </summary>
        public static Color LerpHsvColor(Color from, Color to, float t)
        {
            Color.RGBToHSV(from, out float h1, out float s1, out float v1);
            Color.RGBToHSV(to, out float h2, out float s2, out float v2);

            // Кратчайший путь по кругу Hue
            float hDelta = h2 - h1;
            if (hDelta > 0.5f) h1 += 1f;
            else if (hDelta < -0.5f) h2 += 1f;

            float h = Mathf.Lerp(h1, h2, t);
            if (h > 1f) h -= 1f;
            if (h < 0f) h += 1f;

            return Color.HSVToRGB(h, Mathf.Lerp(s1, s2, t), Mathf.Lerp(v1, v2, t));
        }
    }
}