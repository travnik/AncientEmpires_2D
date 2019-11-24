using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travnik.AncientEmpires
{
    public interface IUnitProvider
    {
        void Load();
        IBaseUnit Get(int x, int y);
        bool Constains(int x, int y);
    }

    public class UnitProvider : IUnitProvider
    {
        private IUnitsContainer _unitsPlayer;

        public UnitProvider(IUnitsContainer unitsPlayer)
        {
            _unitsPlayer = unitsPlayer;
        }

        public void Load()
        {
            _unitsPlayer.Create(PlayerTeam.Blue, UnitType.Human, 1, 1);
        }

        public bool Constains(int x, int y)
        {
            var unit = Get(x, y);
            return unit != null;
        }

        public IBaseUnit Get(int x, int y)
        {
            return _unitsPlayer.Get(x, y);
        }
    }
}
