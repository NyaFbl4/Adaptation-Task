using System;
using Presentation.UI;
using Project.Scripts.Domain.Models;
using Project.Scripts.UseCases;
using R3;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Presentation
{
    public sealed class HeroPresenter : IStartable, IDisposable
    {
        [Inject] private readonly IHeroStatsView _heroView;
        [Inject] private readonly IHeroModel _heroModel;
        [Inject] private readonly HeroUsecase _heroUsecase;
        
        private readonly CompositeDisposable _disposable = new();
        
        public HeroPresenter(HeroView heroView, HeroUsecase heroUsecase, IHeroModel heroModel)
        {
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
            _heroUsecase.LevelUp();
        }
        
        public void Dispose() => _disposable.Dispose();
    }
}