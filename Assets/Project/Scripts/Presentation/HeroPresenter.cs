using System;
using Presentation.UI;
using Project.Scripts.Domain.Models;
using Project.Scripts.UseCases;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Presentation
{
    public class HeroPresenter : IStartable, IDisposable
    {
        private readonly HeroView _heroView;
        private readonly IHeroModel _heroModel;
        private readonly HeroUsecase _heroUsecase;
        private readonly CompositeDisposable _disposable = new();
        
        [Inject]
        public HeroPresenter(HeroView heroView, HeroUsecase heroUsecase, IHeroModel heroModel)
        {
            Debug.Log("HeroPresenter");
            
            _heroView = heroView;
            _heroModel = heroModel;
            _heroUsecase = heroUsecase;
        }
        
        public void Start()
        {
            SubscribeToEvents();
            
            _heroModel.Level.Subscribe(level => _heroView.SetLevel(level));
            _heroModel.Health.Subscribe(health => _heroView.SetHealth(health));
            _heroModel.Attack.Subscribe(attack => _heroView.SetAttack(attack));
        }
        
        private void SubscribeToEvents()
        {
            _heroView.OnButtonClicked
                .Subscribe(_ => OnLevelUpButtonClicked())
                .AddTo(_disposable);
        }
        
        private void OnLevelUpButtonClicked()
        {
            Debug.Log("Presenter обработал клик");
            _heroUsecase.LevelUp();
        }
        
        public void Dispose() => _disposable.Dispose();
    }
}