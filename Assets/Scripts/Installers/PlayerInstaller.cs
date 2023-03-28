using ArcheroLike.Characters;
using UnityEngine;
using Zenject;

namespace ArcheroLike.Installers
{
    /// <summary>
    /// Инсталлер игрока
    /// </summary>
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform spawnPoint;

        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Player>(player,spawnPoint.position,Quaternion.identity,null);

            Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
        }
    }
}