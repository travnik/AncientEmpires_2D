using Assets.Travnik.AncientEmpires.Scripts.Installers;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        public Camera Camera;
        public MapCellConfigurator MapCellConfigurator = new MapCellConfigurator();

        public override void InstallBindings()
        {
            Container.BindInstance(Camera).AsSingle();
            Container.Bind<IGeometry>().To<Geometry2D>().AsSingle();
            Container.Bind<IObjectSelector>().To<Raycast2DSelector>().AsSingle();
            InstallMapBindings();
        }

        private void InstallMapBindings()
        {
            Container.Bind<IMapProvider>().To<MapProvider>().AsSingle();
            Container.BindFactory<MapCellType, MapCell, MapCellFactory>().FromMethod(MapCellConfigurator.CreateMapCellMethodFactory);
        }
    }
}