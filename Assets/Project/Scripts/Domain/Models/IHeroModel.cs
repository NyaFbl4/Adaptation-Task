namespace Project.Scripts.Domain.Models
{
    public interface IHeroModel
    {
        int Level { get; }
        int Health { get; }
        int Attack { get; }

        public void AddHealth(int amount);

        public void AddAttack(int amount);
    }
}