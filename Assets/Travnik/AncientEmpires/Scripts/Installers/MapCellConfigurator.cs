using System;
using System.ComponentModel;
using Travnik.AncientEmpires;
using UnityEngine;
using Zenject;

namespace Assets.Travnik.AncientEmpires.Scripts.Installers
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
