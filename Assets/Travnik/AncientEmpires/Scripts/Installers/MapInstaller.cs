using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class MapInstaller : MonoInstaller<MapInstaller>
    {
        public GameObject GroundPrefab;
        public GameObject GameManager;

        //public override void Start()
        //{
        //    _parentMap = new GameObject("Map");
        //    _parentMap.AddComponent<BoxCollider>();
        //}
        public override void InstallBindings()
        {
            Container.Bind<MapProvider>().AsSingle();
            Container.BindFactory<MapCellType, MapCell, MapCellFactory>().FromMethod(CreateMapCell);
        }

        private MapCell CreateMapCell(DiContainer _, MapCellType type)
        {
            var cell = Container.InstantiatePrefabForComponent<MapCell>(GroundPrefab, GameManager.transform);
            //cell.gameObject.AddComponent<BoxCollider>();
            return cell;
        }
    }
}
