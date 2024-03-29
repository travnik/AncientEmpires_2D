using AncientEmpires;
using Assets.Travnik.AncientEmpires.Scripts.UI.Marker;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        public Camera Camera;
        public FooterPanelPresentor FooterPanelPresentor;
        public HeaderPanelPresentor HeaderPanelPresentor;
        public CursorPresentor CursorPresentor;

        public MapCellConfigurator MapCellConfigurator = new MapCellConfigurator();
        public UnitsConfiguration UnitsConfiguration = new UnitsConfiguration();
        public MarkerMapConfiguration MarkerMapConfiguration = new MarkerMapConfiguration();

        public override void InstallBindings()
        {
            Container.BindInstance(Camera).AsSingle();
            Container.BindInstance(FooterPanelPresentor).AsSingle();
            Container.BindInstance(HeaderPanelPresentor).AsSingle();
            Container.BindInstance(CursorPresentor).AsSingle();

            Container.Bind<IGeometry>().To<Geometry2D>().AsSingle();
            Container.Bind<IObjectSelector>().To<ObjectSelector>().AsSingle();
            Container.Bind<IUnitMovablePositioner>().To<UnitMovablePositioner>().AsSingle();

            InstallMapBindings();
            InstallUnitBindings();
            InstallMarkerMapBindings();
        }

        private void InstallMapBindings()
        {
            Container.Bind<IMapProvider>().To<MapProvider>().AsSingle();
            Container.BindFactory<MapCellType, MapCell, MapCellFactory>().FromMethod(MapCellConfigurator.CreateMapCellMethodFactory);
        }

        private void InstallUnitBindings()
        {
            Container.Bind<IUnitProvider>().To<UnitProvider>().AsSingle();
            Container.BindFactory<PlayerTeam, UnitType, BaseUnit, UnitFactory>().FromMethod(UnitsConfiguration.CreateUnitMethodFactory);
        }

        private void InstallMarkerMapBindings()
        {
            Container.Bind<MarkerMapPresentor>().AsSingle();
            Container.BindFactory<MarkerType, MarkerMap, MarkerMapFactory>().FromMethod(MarkerMapConfiguration.CreateMarkerMapMethodFactory);
        }
    }
}