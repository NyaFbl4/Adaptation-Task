using Project.Scripts.UseCases;
using R3;

namespace Project.Scripts.Infrastructure
{
    public class ExperienceManager
    {
        public ReactiveProperty<int> PropertyExperience = new();
        private UpgradeHeroUsecase _upgradeHeroUsecase;
        
        public void AddExperience(int quantity)
        {
            PropertyExperience.Value += quantity;

            if (PropertyExperience.Value >= 100)
            {
                PropertyExperience.Value -= 100;
                _upgradeHeroUsecase.LevelUp();
            }
            
            //_heroStatsView.ExperienceUpdate(PropertyExperience.Value);
        }
    }
}