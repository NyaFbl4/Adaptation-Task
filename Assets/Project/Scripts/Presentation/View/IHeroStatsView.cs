using R3;

namespace Presentation.UI
{
    public interface IHeroStatsView
    {
        public void SetLevel(int quantity);
        public void SetHealth(int quantity);
        public void SetAttack(int quantity);
    }
}