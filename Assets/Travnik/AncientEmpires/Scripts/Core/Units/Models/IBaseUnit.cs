using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IBaseUnit
    {
        PlayerTeam PlayerTeam { get; }
        Vector2Int ArrayPosition { get; }
        Vector3 WorldPosition { get; }
        int MovePoint { get; }
        Sprite GetIcon();
    }
}