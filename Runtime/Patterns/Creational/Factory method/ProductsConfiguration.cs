using System.Collections.Generic;
using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    [System.Serializable]
    public class ProductsConfiguration<Key, Product> where Product : IProduct<Key>
    {
        [SerializeField] private Product[] _products;
        private Dictionary<Key, Product> _idToProducts;

        public void Init()
        {
            ValidateConfiguration();

            LoadProducts();
        }

        private void ValidateConfiguration()
        {
            if (null == _products || _products.Length <= 0) throw new System.Exception("No products in this configuration: ");
        }

        public bool HaveProducts()
        {
            if (null == _products || _products.Length <= 0) return false;


            return true;
        }

        private void LoadProducts()
        {
            _idToProducts = new Dictionary<Key, Product>(_products.Length);
            foreach (var productObj in _products)
            {
                AddProductToTheConfiguration(productObj);
            }
        }

        #region Add product

        private void AddProductToTheConfiguration(Product product)
        {
            //Product product = (Product)productObj.GetInterface<IProduct<Key>>();

            ValidateProduct(product);

            AddProductIfDontHaveIt(product);
        }

        private void ValidateProduct(Product product)
        {
            if (null == product) throw new System.Exception("No exist product in this gameobject");
        }

        private void AddProductIfDontHaveIt(Product product)
        {
            if (_idToProducts.ContainsKey(product.Id))
                Debug.LogWarning("This configuration is already contains: " + product.Id);
            else
                _idToProducts.Add(product.Id, product);
        }

        #endregion

        public Product GetProductById(Key id)
        {
            if (!_idToProducts.TryGetValue(id, out var product))
            {
                Debug.LogWarning($"Product with id {id} does not exit");
                return default;
            }
            return product;
        }

        public Product[] GetAllProducts()
        {
            return _products;
        } 
    }
}