using UnityEngine;
using UnityEditor;
using CleanCore.Extensions;

namespace CleanCore.EditorExtensions.UnityComponentInspectorExtension
{
	public class CutComponentEditor : Editor
	{
        private static Component _cutComponent;

        [MenuItem("CONTEXT/Object/Cut")]
        public static void Cut(MenuCommand command)
        {
            _cutComponent = (Component)command.context;
            Debug.Log(_cutComponent);
        }

        [MenuItem("CONTEXT/Object/Paste Cut")]
        public static void Paste(MenuCommand command)
        {
            GameObject goToPasteCut = ((Component)command.context).gameObject;
            goToPasteCut.CopyComponent(_cutComponent);

            Debug.Log(_cutComponent);
        }
    }
}