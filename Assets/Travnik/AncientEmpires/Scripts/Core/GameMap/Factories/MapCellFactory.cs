using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class MapCellFactory  : PlaceholderFactory<MapCellType, MapCell>
    {
        private IGeometry _geometry;

        public MapCellFactory(IGeometry geometry)
        {
            _geometry = geometry;
        }

        public IMapCell Create(MapCellType type, int x, int y)
        {
            var cell = base.Create(type);
            cell.ArrayPosition = new Vector2Int(x, y);
            cell.transform.position = _geometry.PointFromGrid(cell.ArrayPosition);
            return cell;
        }
    }
}
