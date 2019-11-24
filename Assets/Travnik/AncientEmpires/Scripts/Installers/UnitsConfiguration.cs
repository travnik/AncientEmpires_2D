using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    [Serializable]
    public class UnitsConfiguration
    {
        public UnitProfile[] UnitProfiles;
        public GameObject GameManager;

        public BaseUnit CreateUnitMethodFactory(DiContainer di, PlayerTeam team, UnitType type)
        {
            var unit = di.InstantiatePrefabForComponent<BaseUnit>(GetPrefab(team, type), GameManager.transform);
            //unit..MapCellInfo = GroundMapCellProfile.MapCellInfo;
            return unit;
        }

        private GameObject GetPrefab(PlayerTeam team, UnitType type)
        {
            return UnitProfiles.Single(o => o.UnitInfo.Type == type).Prefab;
        }
    }
}
