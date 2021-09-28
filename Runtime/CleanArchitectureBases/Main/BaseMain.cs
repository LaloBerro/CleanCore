using CleanCore.CleanArchitectureBases.Domain.UseCases;
using UnityEngine;

namespace CleanCore.CleanArchitectureBases.Main
{
    public abstract class BaseMain : MonoBehaviour, IMain
    {
        protected IUseCase _useCase;

        private void Awake()
        {
            _useCase.Begin();
        }

        private void OnDestroy()
        {
            _useCase.Finish();
        }
    }
}