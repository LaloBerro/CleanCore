using System.Collections;
using UnityEngine;

namespace CleanCore.Extensions
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Return true if the colletion has nodes
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsEmpty(this ICollection collection)
        {
            return collection.Count > 0;
        }
    }
}