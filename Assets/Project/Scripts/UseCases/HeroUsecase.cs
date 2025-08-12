using System;
using Project.Scripts.Domain.Configs;
using Project.Scripts.Domain.Models;
using R3;
using UnityEngine;
using VContainer;

namespace Project.Scripts.UseCases
{
    public sealed class HeroUsecase
    {
        private readonly IHeroModel _heroModel;
        private readonly LevelUpConfig _levelUpConfig;
        
        private readonly CompositeDisposable _disposable = new();

        [Inject]
        public HeroUsecase(IHeroModel heroModel, 
            LevelUpConfig levelUpConfig)
        {
            Debug.Log("HeroUsecase");
            
            _heroModel = heroModel;
            _levelUpConfig = levelUpConfig;
        }

        public void LevelUp()
        {
            Debug.Log("LevelUp");
            
            _heroModel.LevelUp();
            _heroModel.AddHealth(_levelUpConfig.HealthUp);
            _heroModel.AddAttack(_levelUpConfig.AttackUp);
        }
    }
}