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

        public IBaseUnit Create(PlayerTeam team, UnitType type, int x, int y)
        {
            var unit = base.Create(team, type);
            unit.ArrayPosition = new Vector2Int(x, y);
            unit.transform.position = _geometry.PointFromGrid(unit.ArrayPosition);
            return unit;
        }
    }
}