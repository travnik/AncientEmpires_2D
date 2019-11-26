using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IMapCell
    {
        MapCellInfo MapCellInfo { get; }
        Vector2Int ArrayPosition { get; }
        Vector3 WorldPosition { get; }
        Sprite GetIcon();
    }
}