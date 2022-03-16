using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Returns children of self transform.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="nesting">Get children's children or not</param>
        /// <returns>Transform's children enumerable</returns>
        public static IEnumerable<Transform> GetChildren(this Transform self, bool nesting = false)
        {
            var childs = EnumerablesHelper.For(value => self.GetChild(value), self.childCount); 
            if (!nesting || self.childCount == 0)
            {
                return childs;
            }
            else
            {
                return childs.Concat(childs.SelectMany(value => value.GetChildren()));
            }
        }

        /// <summary>
        /// Returns children of self transform with specified nesting level.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="nestingLevel">Specified nesting level</param>
        /// <returns>Transform's children enumerable</returns>
        public static IEnumerable<Transform> GetChildren(this Transform self, int nestingLevel)
        {
            var childs = self.GetChildren(false);
            if (nestingLevel <= 1 || self.childCount == 0)
            {
                return childs;
            }
            else
            {
                return childs.Concat(childs.SelectMany(value => value.GetChildren(nestingLevel - 1))).ToArray();
            }
        }

        /// <summary>
        /// Checks is other transform is child of self.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="other">Another transform</param>
        /// <param name="nesting">Check the nested transforms or not</param>
        /// <returns>True if other is child of self and false otherwise</returns>
        public static bool IsParentOf(this Transform self, Transform other, bool nesting = false)
        {
            if (nesting)
            {
                return self.GetChildren(true).Contains(other);
            }
            else
            {
                return other.IsChildOf(self);
            }
        }

        /// <summary>
        /// Creates TRS-matrix from transform.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <returns>TRS-matrix</returns>
        public static Matrix4x4 GetTRSMatrix(this Transform self)
        {
            return Matrix4x4.TRS(self.position, self.rotation, self.localScale);
        }

        /// <summary>
        /// Applies the TRS-matrix to self transform.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="matrix">Matrix to apply</param>
        /// <exception cref="ArgumentException">Not valid matrix</exception>
        public static void SetTRSMatrix(this Transform self, Matrix4x4 matrix)
        {
            if (!matrix.ValidTRS())
            {
                throw new ArgumentException("Not valid matrix.", nameof(matrix));
            }

            self.rotation = matrix.GetRotation();
            self.position = matrix.GetPosition();
            self.localScale = matrix.GetScale();
        }
    }
}
