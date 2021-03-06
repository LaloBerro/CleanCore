using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    /// <summary>
    /// K is the type of the key in the dictionary of products
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class Factory<Key, Product> where Product : IProduct<Key>
    {
        private readonly ProductsConfiguration<Key, Product> _productConfiguration;

        public Factory(ProductsConfiguration<Key, Product> productConfiguration)
        {
            this._productConfiguration = productConfiguration;

            productConfiguration.Init();
        }

        public Product Create(Key id)
        {
            var product = _productConfiguration.GetProductById(id);

            return product;
        }

        public bool Contains(Key id)
        {
            return _productConfiguration.ContainsProduct(id);
        }
    }
}