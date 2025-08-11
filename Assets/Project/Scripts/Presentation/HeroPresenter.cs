using System;
using Presentation.UI;
using Project.Scripts.Domain.Models;
using Project.Scripts.UseCases;
using R3;

namespace Project.Scripts.Presentation
{
    public class HeroPresenter : IDisposable
    {
        private readonly IHeroModel _heroModel;
        private readonly HeroView _heroView;
        private readonly UpgradeHeroUsecase _upgradeHeroUsecase;
        
        private readonly CompositeDisposable _disposable = new();

        public HeroPresenter(IHeroModel heroModel ,HeroView heroView, 
            UpgradeHeroUsecase upgradeHeroUsecase)
        {
            _heroModel = heroModel;
            _heroView = heroView;
            _upgradeHeroUsecase = upgradeHeroUsecase;
        }

        public void Initialize()
        {
            _upgradeHeroUsecase.LevelUp();
        }

        public void Dispose() => _disposable.Clear();
    }
}