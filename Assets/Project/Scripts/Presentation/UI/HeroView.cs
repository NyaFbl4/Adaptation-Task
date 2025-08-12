using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation.UI
{
    public sealed class HeroView : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;

        private Subject<Unit> _buttonClickSubject = new();
        public Observable<Unit> OnButtonClicked => _buttonClickSubject;
        
        private Button _levelUpButton;
        
        private Label _levelTextLabel;
        private Label _healthTextLabel;
        private Label _attackTextLabel;
        

        private void Awake()
        {
            if (_uiDocument == null)
                _uiDocument = GetComponent<UIDocument>();

            var root = _uiDocument.rootVisualElement;

            _levelUpButton = root.Q<Button>("ButtonLevelUp");

            _levelTextLabel  = root.Q<Label>("LevelTextInfo");
            _healthTextLabel = root.Q<Label>("HealthTextInfo");
            _attackTextLabel = root.Q<Label>("AttackTextInfo");

            _levelUpButton?.RegisterCallback<ClickEvent>(_ => 
            {
                _buttonClickSubject.OnNext(Unit.Default);
            });
        }
        
        private void OnDestroy()
        {
            _buttonClickSubject.OnCompleted();
            _buttonClickSubject.Dispose();
        }
        
        public void SetLevel(int quantity) => _levelTextLabel.text = quantity.ToString();
        public void SetHealth(int quantity) => _healthTextLabel.text = quantity.ToString();
        public void SetAttack(int quantity) => _attackTextLabel.text = quantity.ToString();
    }
}