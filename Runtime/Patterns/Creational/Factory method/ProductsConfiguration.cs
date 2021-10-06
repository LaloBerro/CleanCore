using System.Collections.Generic;
using UnityEngine;
using System;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    [Serializable]
    public class ProductsConfiguration<K>
	{
        [SerializeField] private GameObject[] products;
        private Dictionary<K, IProduct<K>> idToProducts;

        public void Init()
        {
            ValidateConfiguration();

            LoadProducts();
        }

        private void ValidateConfiguration()
        {
            if (null == products || products.Length <= 0) throw new Exception("No products in this configuration: ");
        }

        public bool HaveProducts()
        {
            if (null == products || products.Length <= 0) return false;


            return true;
        }

        private void LoadProducts()
        {
            idToProducts = new Dictionary<K, IProduct<K>>(products.Length);
            foreach (var productObj in products)
            {
                AddProductToTheConfiguration(productObj);
            }
        }

        #region Add product

        private void AddProductToTheConfiguration(GameObject productObj)
        {
            IProduct<K> product = productObj.GetComponent<IProduct<K>>();

            ValidateProduct(product);

            AddProductIfDontHaveIt(product);
        }

        private void ValidateProduct(IProduct<K> product)
        {
            if (null == product) throw new Exception("No exist product in this gameobject");
        }

        private void AddProductIfDontHaveIt(IProduct<K> product)
        {
            if (idToProducts.ContainsKey(product.Id))
                Debug.LogWarning("This configuration is already contains: " + product.Id);
            else
                idToProducts.Add(product.Id, product);
        }

        #endregion

        public IProduct<K> GetProductById(K id)
        {
            if (!idToProducts.TryGetValue(id, out var product))
            {
                Debug.LogWarning($"Product with id {id} does not exit");
                return null;
            }
            return product;
        }
    }
}