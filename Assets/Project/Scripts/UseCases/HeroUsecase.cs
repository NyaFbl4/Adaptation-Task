using Project.Scripts.Domain.Configs;
using Project.Scripts.Domain.Models;
using VContainer;

namespace Project.Scripts.UseCases
{
    public sealed class HeroUsecase : IHeroUsecase
    {
        [Inject] private readonly IHeroModel _heroModel;
        [Inject] private readonly LevelUpConfig _levelUpConfig;

        public HeroUsecase(IHeroModel heroModel, LevelUpConfig levelUpConfig)
        {
            _heroModel = heroModel;
            _levelUpConfig = levelUpConfig;
        }

        public void LevelUp()
        {
            _heroModel.LevelUp();
            _heroModel.AddHealth(_levelUpConfig.HealthUp);
            _heroModel.AddAttack(_levelUpConfig.AttackUp);
        }
    }
}