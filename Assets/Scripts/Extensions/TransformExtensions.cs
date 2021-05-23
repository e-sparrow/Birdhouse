using System.Linq;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Возвращает все дочерние объекты Transform'а.
        /// </summary>
        public static Transform[] GetChilds(this Transform transform)
        {
            return CollectionsHelper.For(value => transform.GetChild(value), transform.childCount).ToArray();
        }
    }
}
