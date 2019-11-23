using System;
using Assets.Travnik.AncientEmpires.Scripts.Installers.Config;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    [Serializable]
    public class MapCellConfigurator
    {
        public MapCellProfile GroundMapCellProfile;
        public GameObject GameManager;

        public MapCell CreateMapCellMethodFactory(DiContainer di, MapCellType type)
        {
            var cell = di.InstantiatePrefabForComponent<MapCell>(GetPrefab(), GameManager.transform);
            //cell.gameObject.AddComponent<BoxCollider>();
            return cell;
        }

        private GameObject GetPrefab()
        {
            return GroundMapCellProfile.GetRandomPrefab();
        }
    }
}
