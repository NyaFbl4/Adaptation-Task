using UnityEngine;

namespace Project.Scripts.Domain.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Configs/HeroConfig")]
    public class StartHeroConfig : ScriptableObject
    {
        [SerializeField] private int _startLevel;
        [SerializeField] private int _startHealth;
        [SerializeField] private int _startAttack;

        public int StartLevel => _startLevel;
        public int StartHealth => _startHealth;
        public int StartAttack => _startAttack;
    }
}