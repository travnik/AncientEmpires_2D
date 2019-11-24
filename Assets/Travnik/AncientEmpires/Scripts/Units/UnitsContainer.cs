using System;
using System.Collections.Generic;
using System.Linq;

namespace Travnik.AncientEmpires
{
    public interface IUnitsContainer
    {
        IEnumerable<IBaseUnit> Get();

        IBaseUnit Get(int x, int y);
        IBaseUnit Create(PlayerTeam team, UnitType type, int x, int y);
    }

    public class UnitsContainer : IUnitsContainer
    {
        private readonly UnitFactory _unitFactory;
        private readonly List<IBaseUnit> Units = new List<IBaseUnit>();

        public readonly PlayerTeam PlayerTeam = PlayerTeam.Red;

        public UnitsContainer(UnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public IEnumerable<IBaseUnit> Get()
        {
            return Units;
        }

        public IBaseUnit Get(int x, int y)
        {
            return Units.SingleOrDefault(o => o.ArrayPosition.x == x && o.ArrayPosition.y == y);
        }

        public IBaseUnit Create(PlayerTeam team, UnitType type, int x, int y)
        {
            var unit = _unitFactory.Create(PlayerTeam, type, x, y);
            Units.Add(unit);
            return unit;
        }
    }
}
