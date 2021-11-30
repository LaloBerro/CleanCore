using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    public abstract class MonoFactory<keyType, ProductType> : MonoBehaviour where ProductType : IProduct<keyType>
    {
        [Header("Factory References")]
        [SerializeField] private ProductsConfiguration<keyType, ProductType> _productsConfiguration;

        private Factory<keyType, ProductType> _factory;

        public abstract ProductType Create(keyType key);
    }
}