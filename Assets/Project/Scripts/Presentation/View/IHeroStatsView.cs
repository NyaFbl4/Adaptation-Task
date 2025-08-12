using R3;

namespace Presentation.UI
{
    public interface IHeroStatsView
    {
         Observable<Unit> OnButtonClicked { get; }
        
        public void SetLevel(int quantity);
        public void SetHealth(int quantity);
        public void SetAttack(int quantity);
    }
}