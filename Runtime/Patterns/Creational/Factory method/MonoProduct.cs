using UnityEngine;

namespace CleanCore.Patterns.Creational.FactoryMethod
{
    public abstract class MonoProduct<Type> : MonoBehaviour, IProduct<Type>
    {
        [Header("Product References")]
        [SerializeField] private Type _id;

        public Type Id => _id;
    }
}