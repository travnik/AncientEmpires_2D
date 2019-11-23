using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    [CreateAssetMenu(menuName = "Units/Profile")]
    public class UnitProfile : ScriptableObject
    {
        public GameObject UnitView;
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
