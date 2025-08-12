using R3;

namespace Project.Scripts.Domain.Models
{
    public interface IHeroModel
    {
        ReadOnlyReactiveProperty<int>  Level { get; }
        ReadOnlyReactiveProperty<int>  Health { get; }
        ReadOnlyReactiveProperty<int>  Attack { get; }

        public void LevelUp();
        public void AddHealth(int amount);
        public void AddAttack(int amount);
    }
}