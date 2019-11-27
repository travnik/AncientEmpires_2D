using System;
using AncientEmpires;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    [Serializable]
    public class MarkerMapConfiguration
    {
        public GameObject GameManager;
        public GameObject MovePrefab;
        public GameObject AttackPrefab;

        public MarkerMap CreateMarkerMapMethodFactory(DiContainer di, MarkerType type)
        {
            var marker = di.InstantiatePrefabForComponent<MarkerMap>(GetPrefab(type), GameManager.transform);
            return marker;
        }

        private GameObject GetPrefab(MarkerType type)
        {
            switch (type)
            {
                case MarkerType.Move:
                    return MovePrefab;
                case MarkerType.Attack:
                    return AttackPrefab;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
