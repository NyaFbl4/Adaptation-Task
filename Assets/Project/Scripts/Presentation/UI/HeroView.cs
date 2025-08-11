using Project.Scripts.Domain.Models;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Presentation.UI
{
    public class HeroView : VisualElement
    {
        [SerializeField] private UIDocument _uiDocument;
        
        private readonly IHeroModel _heroModel;
        private readonly Button _levelUpButton;

        public void UpdateStats()
        {
            /*
            this.Q<Label>("LevelTextInfo").text = $"Level: {_heroModel.Level}";
            this.Q<Label>("HealthTextInfo").text = $"Level: {_heroModel.Health}";
            this.Q<Label>("AttackTextInfo").text = $"Level: {_heroModel.Attack}";
            */
        }
    }
}