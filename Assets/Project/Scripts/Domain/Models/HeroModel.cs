using System;
using R3;

namespace Project.Scripts.Domain.Models
{
    public class HeroModel : IHeroModel, IDisposable
    {
        private readonly ReactiveProperty<int> _level;
        private readonly ReactiveProperty<int> _health;
        private readonly ReactiveProperty<int> _attack;
        
        public ReadOnlyReactiveProperty<int> Level { get; }
        public ReadOnlyReactiveProperty<int> Health { get; }
        public ReadOnlyReactiveProperty<int> Attack { get; }

        public HeroModel(int level, int health, int attack)
        {
            _level = new ReactiveProperty<int>(level);
            _health = new ReactiveProperty<int>(health);
            _attack = new ReactiveProperty<int>(attack);
            
            Level = _level.ToReadOnlyReactiveProperty();
            Health = _health.ToReadOnlyReactiveProperty();
            Attack = _attack.ToReadOnlyReactiveProperty();
        }

        public void LevelUp() => _level.Value++;
        public void AddHealth(int amount) => _health.Value += amount;
        public void AddAttack(int amount) => _attack.Value += amount;

        public void Dispose()
        {
            Level?.Dispose();
            Health?.Dispose();
            Attack?.Dispose();
        }
    }
}