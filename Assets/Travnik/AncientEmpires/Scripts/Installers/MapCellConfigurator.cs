using System;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    [Serializable]
    public class MapCellConfigurator
    {
        public GameObject[] GroundPrefabs;
        public GameObject GameManager;

        public MapCell CreateMapCellMethodFactory(DiContainer di, MapCellType type)
        {
            var cell = di.InstantiatePrefabForComponent<MapCell>(GetPrefab(), GameManager.transform);
            //cell.gameObject.AddComponent<BoxCollider>();
            return cell;
        }

        public GameObject GetPrefab()
        {
            int randomIndex = UnityEngine.Random.Range(0, GroundPrefabs.Length);
            return GroundPrefabs[randomIndex];
        }
    }
}
