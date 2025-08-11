using Presentation.UI;
using Project.Scripts.Domain.Configs;
using Project.Scripts.Domain.Models;
using Project.Scripts.Presentation;
using Project.Scripts.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Infrastructure
{
    public class Installer : LifetimeScope
    {
        [SerializeField] private LevelUpConfig _levelUpConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_levelUpConfig);
        }
    }
}