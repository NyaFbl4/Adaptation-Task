using Presentation.UI;
using Project.Scripts.Domain.Configs;
using Project.Scripts.Domain.Models;
using Project.Scripts.Presentation;
using Project.Scripts.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Infrastructure
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private StartHeroConfig _startHeroConfig;
        [SerializeField] private LevelUpConfig _levelUpConfig;
        
        [SerializeField] private HeroView _heroView;

        private IHeroModel _heroModel;
        
        protected override void Configure(IContainerBuilder builder)
        {
            HeroRegister(builder);
            ViewsRegister(builder);
        }

        private void HeroRegister(IContainerBuilder builder)
        {
            _heroModel = new HeroModel(
                _startHeroConfig.StartLevel,
                _startHeroConfig.StartHealth,
                _startHeroConfig.StartAttack
            );
            
            builder.RegisterInstance(_heroModel).As<IHeroModel>();
            builder.RegisterInstance(_levelUpConfig).AsSelf();
            
            builder.Register<HeroUsecase>(Lifetime.Scoped).AsSelf();
            builder.RegisterEntryPoint<HeroPresenter>();
        }

        private void ViewsRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(_heroView).As<IHeroStatsView>();
        }
    }
}