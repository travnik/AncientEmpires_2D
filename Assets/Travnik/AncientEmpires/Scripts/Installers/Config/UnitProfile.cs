using System;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    [CreateAssetMenu(menuName = "Units/Profile")]
    public class UnitProfile : ScriptableObject
    {
        public GameObject Prefab;
        public UnitInfo UnitInfo = new UnitInfo();
    }

    [Serializable]
    public class UnitInfo
    {
        public UnitType Type;
        public string Name = "Warrior";
        public string Description;
        public int Cost = 150;
        public int CountMove = 5;
        public CostUnitMove[] CostUnitMoves;
    }

    [Serializable]
    public class CostUnitMove
    {
        public MapCellType CellType;
        public int Cost;
    }
}
