using System;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IMapCell
    {
        int Cost { get; }
        Vector2Int ArrayPosition { get; }
        Vector3 WorldPosition { get; }
    }

    public class MapCell : MonoBehaviour, IMapCell
    {
        public int Cost { get; private set; }
        public Vector2Int ArrayPosition { get; set; }
        public Vector3 WorldPosition { get; set; }
    }
}
