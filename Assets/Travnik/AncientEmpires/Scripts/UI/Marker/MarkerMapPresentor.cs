using System.Collections.Generic;
using System.Linq;
using AncientEmpires;
using Assets.Travnik.AncientEmpires.Scripts.UI.Marker;

namespace Travnik.AncientEmpires
{
    public class MarkerMapPresentor
    {
        private readonly MarkerMapFactory _markerMapFactory;
        private readonly List<MarkerMap> _markerMaps = new List<MarkerMap>();

        public MarkerMapPresentor(MarkerMapFactory markerMapFactory)
        {
            _markerMapFactory = markerMapFactory;
        }

        public void ShowMarker(IEnumerable<MoveStep> steps)
        {
            foreach (var step in steps)
            {
                var marker = _markerMapFactory.Create(MarkerType.Move, step.Position);
                _markerMaps.Add(marker);
            }
        }
    }
}
