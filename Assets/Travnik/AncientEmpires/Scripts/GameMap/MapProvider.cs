using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travnik.AncientEmpires;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public class MapProvider
    {
        private readonly MapCellFactory _mapCellFactory;

        public MapProvider(MapCellFactory mapCellFactory)
        {
            _mapCellFactory = mapCellFactory;
        }

        public int SizeX => _mapCells.GetLength(0);
        public int SizeY => _mapCells.GetLength(1);

        private MapCell[,] _mapCells = new MapCell[10, 5];

        public void Load()
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    var cell = _mapCellFactory.Create();
                    cell.ArrayPosition = new Vector2Int(i, j);
                    _mapCells[i, j] = cell;
                    //TODO
                }
            }
        }

        public IMapCell Get(int x, int y)
        {
            if (IsValid(x, y))
            {
                return _mapCells[x, y];
            }
            throw new IndexOutOfRangeException();
        }

        public bool IsValid(int x, int y)
        {
            return x >= 0 && x < SizeX && y >= 0 && y < SizeY;
        }
    }
}
