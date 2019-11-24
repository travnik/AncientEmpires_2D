using System;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    [CreateAssetMenu(menuName = "MapCells/Profile")]
    public class MapCellProfile : ScriptableObject
    {
        public MapCellInfo MapCellInfo = new MapCellInfo();
        public GameObject[] Prefabs;

        public GameObject GetRandomPrefab()
        {
            var randomIndex = UnityEngine.Random.Range(0, Prefabs.Length);
            return Prefabs[randomIndex];
        }
    }

    [Serializable]
    public class MapCellInfo
    {
        public string Name;
        public int Defense;
        public int CostMove;
        public MapCellType MapCellType;
    }
}
