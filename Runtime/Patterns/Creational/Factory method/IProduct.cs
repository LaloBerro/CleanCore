namespace CleanCore.Patterns.Creational.FactoryMethod
{
	public interface IProduct<K>
	{
		K Id { get; }
	}
}