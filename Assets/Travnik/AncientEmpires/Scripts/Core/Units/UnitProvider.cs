using System.Collections.Generic;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IUnitProvider
    {
        void Load();
        IBaseUnit Get(Vector2Int point);
        bool Constains(Vector2Int point);
    }

    public class UnitProvider : IUnitProvider
    {
        private readonly UnitFactory _unitFactory;
        private readonly Dictionary<Vector2Int, IBaseUnit> _units = new Dictionary<Vector2Int, IBaseUnit>();

        public UnitProvider(UnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public void Load()
        {
            var point = new Vector2Int(2, 1);
            var unit = _unitFactory.Create(PlayerTeam.Blue, UnitType.Human, point);
            _units.Add(point, unit);
        }

        public bool Constains(Vector2Int point)
        {
            return _units.ContainsKey(point);
        }

        public IBaseUnit Get(Vector2Int point)
        {
            return Constains(point) ? _units[point] : null;
        }
    }
}
