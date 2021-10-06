using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    public class ScriptableProductsConfiguration<Key> : ScriptableObject
    {
        [Header("Config")]
        [SerializeField] private ProductsConfiguration<Key> productsConfiguration;
    }
}