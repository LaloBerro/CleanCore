using UnityEngine;
using UnityEditor;
using CleanCore.Patterns.Creational.FactoryMethod;

namespace CleanCore.EditorExtensions.CustomComponentInspector
{
	[CustomEditor(typeof(ProductsConfiguration<>),true)]
	public class ProductConfigurationCustomInpector : Editor
	{
        public override void OnInspectorGUI()
        {
            ProductsConfiguration<string> productsConfiguration = (ProductsConfiguration<string>)target;

            if (!productsConfiguration.HaveProducts())
            {
                GUI.color = Color.red;
                GUILayout.Box("NO HAVE PRODUCTS");

                GUILayout.BeginVertical("Box");
                GUI.color = Color.white;
                EditorGUI.indentLevel++;
                base.OnInspectorGUI();
                GUILayout.EndVertical();
            }
            else
                base.OnInspectorGUI();
        }
    }
}