using Project.Scripts.Domain.Configs;
using Project.Scripts.Domain.Models;

namespace Project.Scripts.UseCases
{
    public class UpgradeHeroUsecase
    {
        private readonly IHeroModel _heroModel;
        private readonly LevelUpConfig _levelUpConfig;

        public UpgradeHeroUsecase(IHeroModel heroModel, LevelUpConfig levelUpConfig)
        {
            _heroModel = heroModel;
            _levelUpConfig = levelUpConfig;
        }

        public void LevelUp()
        {
            _heroModel.AddHealth(_levelUpConfig.AttackUp);
            _heroModel.AddAttack(_levelUpConfig.HealthUp);
        }
    }
}