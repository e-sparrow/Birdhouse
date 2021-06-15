using System;
using System.Linq;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Возвращает все дочерние объекты Transform'а.
        /// Если nested, то возв
        /// </summary>
        public static Transform[] GetChilds(this Transform transform, bool nested = false)
        {
            var childs = CollectionsHelper.For(value => transform.GetChild(value), transform.childCount).ToArray(); 
            if (!nested || transform.childCount == 0)
            {
                return childs;
            }
            else
            {
                return childs.Concat(childs.SelectMany(value => value.GetChilds())).ToArray();
            }
        }

        /// <summary>
        /// Получает дочерние объекты Transform, вложенные в него до nestingLevel раз.
        /// </summary>
        public static Transform[] GetChilds(this Transform transform, int nestingLevel)
        {
            var childs = transform.GetChilds(false);
            if (nestingLevel <= 1 || transform.childCount == 0)
            {
                return childs;
            }
            else
            {
                return childs.Concat(childs.SelectMany(value => value.GetChilds(nestingLevel - 1))).ToArray();
            }
        }

        /// <summary>
        /// Получает матрицу из компонента Transform.
        /// </summary>
        public static Matrix4x4 GetTRSMatrix(this Transform transform)
        {
            return Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        }

        /// <summary>
        /// Применяет к компоненту Transform значения матрицы.
        /// </summary>
        public static void SetTRSMatrix(this Transform transform, Matrix4x4 matrix)
        {
            if (!matrix.ValidTRS())
            {
                throw new ArgumentException("Not valid matrix inputed.", "matrix");
            }

            transform.rotation = matrix.GetRotation();
            transform.position = matrix.GetPosition();
            transform.localScale = matrix.GetScale();
        }
    }
}
