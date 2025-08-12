using System;
using MessagePipe;
using Presentation.UI;
using Domain.Models;
using UseCases;
using R3;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Presentation
{
    public sealed class HeroPresenter : IStartable, IDisposable
    {
        [Inject] private readonly IHeroStatsView _heroStatsView;
        [Inject] private readonly IHeroModel _heroModel;
        [Inject] private readonly IHeroUsecase _heroUsecase;
        
        private readonly CompositeDisposable _disposable = new();

        [Inject] private ISubscriber<Unit> _levelUpSubscriber;
        
        public void Start()
        {
            _levelUpSubscriber
                .Subscribe(_ => OnLevelUpButtonClicked())
                .AddTo(_disposable);
            
            _heroModel.Level
                .Subscribe(level => _heroStatsView.SetLevel(level))
                .AddTo(_disposable);
            
            _heroModel.Health
                .Subscribe(health => _heroStatsView.SetHealth(health))
                .AddTo(_disposable);
            
            _heroModel.Attack
                .Subscribe(attack => _heroStatsView.SetAttack(attack))
                .AddTo(_disposable);
        }

        private void OnLevelUpButtonClicked()
        {
            _heroUsecase.LevelUp();
        }
        
        public void Dispose() => _disposable.Dispose();
    }
}