using AncientEmpires;
using Travnik.AncientEmpires;
using UnityEngine;
using Zenject;

namespace Assets.Travnik.AncientEmpires.Scripts.UI.Marker
{
    public class MarkerMapFactory : PlaceholderFactory<MarkerType, MarkerMap>
    {
        private IGeometry _geometry;

        public MarkerMapFactory(IGeometry geometry)
        {
            _geometry = geometry;
        }

        public MarkerMap Create(MarkerType type, Vector2Int position)
        {
            var marker = base.Create(type);
            marker.transform.position = _geometry.PointFromGrid(position);
            return marker;
        }
    }
}
