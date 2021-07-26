using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
	/// <summary>
	/// K is the type of the key in the dictionary of products
	/// </summary>
	/// <typeparam name="K"></typeparam>
	public abstract class Factory<K>
	{
		private readonly ProductsConfiguration<K> productConfiguration;

		public Factory(ProductsConfiguration<K> productConfiguration)
		{
			this.productConfiguration = productConfiguration;

			productConfiguration.Init();
		}

		public IProduct<K> Create(K id)
		{
			var product = productConfiguration.GetProductById(id);

			return product;
		}
	}
}