using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    [CreateAssetMenu(fileName = "StringConfiguration", menuName = "ProductsConfiguration/with String key")]
    public class StringScriptableProductsConfiguration : ScriptableProductsConfiguration<string>
    {
    }
}