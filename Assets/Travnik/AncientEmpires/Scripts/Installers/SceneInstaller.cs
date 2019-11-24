using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        public Camera Camera;
        public MapCellConfigurator MapCellConfigurator = new MapCellConfigurator();
        public IconPanelPresentor IconPanelPresentor;
        public UnitsConfiguration UnitsConfiguration = new UnitsConfiguration();

        public override void InstallBindings()
        {
            Container.BindInstance(Camera).AsSingle();
            Container.Bind<IGeometry>().To<Geometry2D>().AsSingle();
            Container.Bind<IObjectSelector>().To<Raycast2DSelector>().AsSingle();
            Container.BindInstance(IconPanelPresentor).AsSingle();
            InstallMapBindings();
            InstallUnitBindings();
        }

        private void InstallMapBindings()
        {
            Container.Bind<IMapProvider>().To<MapProvider>().AsSingle();
            Container.BindFactory<MapCellType, MapCell, MapCellFactory>().FromMethod(MapCellConfigurator.CreateMapCellMethodFactory);
        }

        private void InstallUnitBindings()
        {
            Container.Bind<IUnitsContainer>().To<UnitsContainer>().AsTransient();
            Container.Bind<IUnitProvider>().To<UnitProvider>().AsSingle();
            Container.BindFactory<PlayerTeam, UnitType, BaseUnit, UnitFactory>().FromMethod(UnitsConfiguration.CreateUnitMethodFactory);
        }
    }
}