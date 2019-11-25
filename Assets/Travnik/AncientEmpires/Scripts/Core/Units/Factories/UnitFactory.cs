using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class UnitFactory : PlaceholderFactory<PlayerTeam, UnitType, BaseUnit>
    {
        private IGeometry _geometry;

        public UnitFactory(IGeometry geometry)
        {
            _geometry = geometry;
        }

        public IBaseUnit Create(PlayerTeam team, UnitType type, Vector2Int point)
        {
            var unit = base.Create(team, type);
            unit.ArrayPosition = point;
            unit.transform.position = _geometry.PointFromGrid(unit.ArrayPosition);
            return unit;
        }
    }
}