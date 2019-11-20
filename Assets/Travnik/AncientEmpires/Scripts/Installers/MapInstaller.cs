﻿using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class MapInstaller : MonoInstaller<MapInstaller>
    {
        public GameObject GroundPrefab;

        public override void InstallBindings()
        {
            //Container.BindInstance(GroundPrefab).AsSingle();
            //<UnityEngine.Object>().WithId(MapCellType.Ground).FromComponentInNewPrefab(GroundPrefab).AsSingle();
            //Container.Bind<MapProvider>().AsSingle();
            //Container.Bind<MapCell>().FromComponentInNewPrefab(GroundPrefab).AsTransient();
            //Container.BindFactory<MapCell, MapCellFactory>().FromComponentInNewPrefab(GroundPrefab);//.FromFactory<CustomMapCellFactory>();

            //Container.BindInstance(Camera).AsSingle();

            //Container.BindInstance(TestPlayer).AsSingle();
            //Container.Bind<IObjectSelector>().To<Raycast2DSelector>().AsSingle();

            //Container.Bind<MapFactory>().AsSingle();
            //Container.Bind<UnityEngine.Object>().FromInstance(GroundPrefab).WhenInjectedInto<MapFactory>();
            Container.Bind<MapProvider>().AsSingle();
            Container.BindFactory<MapCellType, MapCell, MapCellFactory>().FromMethod(CreateMapCell);
        }

        private MapCell CreateMapCell(DiContainer _, MapCellType type)
        {
            return Container.InstantiatePrefabForComponent<MapCell>(GroundPrefab);
        }
    }
}
