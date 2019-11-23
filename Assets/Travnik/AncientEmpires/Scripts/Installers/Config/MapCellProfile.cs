using Travnik.AncientEmpires;
using UnityEngine;

namespace Assets.Travnik.AncientEmpires.Scripts.Installers.Config
{
    [CreateAssetMenu(menuName = "MapCells/Profile")]
    public class MapCellProfile : ScriptableObject
    {
        public string Name;
        public int Defense;
        public int CostMove;
        public MapCellType MapCellType;
        public GameObject[] Prefabs;

        public GameObject GetRandomPrefab()
        {
            var randomIndex = UnityEngine.Random.Range(0, Prefabs.Length);
            return Prefabs[randomIndex];
        }
    }
}
