namespace Project.Scripts.Domain.Models
{
    public class HeroModel : IHeroModel
    {
        private int _level;
        private int _health;
        private int _attack;

        private int _experience;
        
        public int Level => _level;
        public int Health => _health;
        public int Attack => _attack;
        //public int Experience => _experience;

        public void AddHealth(int amount) => _health += amount;
        public void AddAttack(int amount) => _attack += amount;
    }
}