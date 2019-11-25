using System;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IMapProvider
    {
        int SizeX { get; }
        int SizeY { get; }
        void Load();
        IMapCell Get(int x, int y);
        bool IsValid(int x, int y);
    }

    public class MapProvider : IMapProvider
    {
        private readonly MapCellFactory _mapCellFactory;

        public MapProvider(MapCellFactory mapCellFactory)
        {
            _mapCellFactory = mapCellFactory;
        }

        public int SizeX => _mapCells.GetLength(0);
        public int SizeY => _mapCells.GetLength(1);

        private IMapCell[,] _mapCells = new IMapCell[10, 5];

        public void Load()
        {
            for (var i = 0; i < SizeX; i++)
            {
                for (var j = 0; j < SizeY; j++)
                {
                    var cell = _mapCellFactory.Create(MapCellType.Ground, i, j);
                    //cell.transform.parent = this;
                    
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
