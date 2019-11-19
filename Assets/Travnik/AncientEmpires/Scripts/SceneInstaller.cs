                                                                                                                                                                                                                                                                                                                                                                                          using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class SceneInstaller : MonoInstaller
    {
        public Player TestPlayer;
        public Camera Camera;

        public override void InstallBindings()
        {
            Container.Bind<MapProvider>().AsSingle();
            Container.Bind<IMapCell>().FromNewComponentOnNewGameObject();
            Container.BindFactory<MapCell, MapCellFactory>().FromFactory<CustomMapCellFactory>();

            Container.BindInstance(Camera).AsSingle();

            Container.BindInstance(TestPlayer).AsSingle();
            Container.Bind<IObjectSelector>().To<Raycast2DSelector>().AsSingle();
        }
    }
}