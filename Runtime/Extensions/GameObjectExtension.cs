using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CleanCore.Extensions
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// Perform an action if a component exists, skip otherwise
        /// </summary>
        /// <typeparam name="T">The type of component required</typeparam>
        /// <param name="self"></param>
        /// <param name="callback">The action to take</param>
        /// <returns>The component found</returns>
        public static T GetComponent<T>(this GameObject self, System.Action<T> callback) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                callback.Invoke(component);
            }

            return component;
        }

        /// <summary>
        /// Get a component, take a different action if it isn't there
        /// </summary>
        /// <typeparam name="T">Component Type</typeparam>
        /// <param name="self">object being extended</param>
        /// <param name="success">Take this action if the component exists</param>
        /// <param name="failure">Take this action if the component does not exist</param>
        /// <returns></returns>
        public static T GetComponent<T>(this GameObject self, System.Action<T> success, System.Action failure) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                success.Invoke(component);
                return component;
            }
            else
            {
                failure.Invoke();
                return null;
            }
        }

        public static T CopyComponent<T>(this GameObject destination,  T original ) where T : Component
        {
            System.Type type = original.GetType();
            Component copy = destination.AddComponent(type);
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                field.SetValue(copy, field.GetValue(original));
            }
            return copy as T;
        }

        public static T GetInterface<T>(this GameObject selfObj) where T : class
        {
            if (!typeof(T).IsInterface)
            {
                Debug.LogError(typeof(T).ToString() + ": is not an actual interface!");
                return null;
            }

            T interfaceTypeComponent = selfObj.GetComponents<Component>().OfType<T>().FirstOrDefault();

            if (null == interfaceTypeComponent)
                throw new System.Exception("There is not a interface of type " + typeof(T).Name + " in gameobject " + selfObj.name);

            return interfaceTypeComponent;
        }

        public static IEnumerable<T> GetInterfaces<T>(this GameObject inObj) where T : class
        {
            if (!typeof(T).IsInterface)
            {
                Debug.LogError(typeof(T).ToString() + ": is not an actual interface!");
                return Enumerable.Empty<T>();
            }

            return inObj.GetComponents<Component>().OfType<T>();
        }

    }
}