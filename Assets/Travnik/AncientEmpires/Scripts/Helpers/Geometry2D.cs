using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IGeometry
    {
        Vector3 PointFromGrid(Vector2Int gridPoint);
        Vector2Int GridFromPoint(Vector3 point);
        Vector3 PointFromGrid(int x, int y);
    }

    public class Geometry2D : IGeometry
    {
        public const float Bias = 0.5f;
        public const int DirectionY = -1;

        public Vector3 PointFromGrid(Vector2Int gridPoint)
        {
            return PointFromGrid(gridPoint.x, gridPoint.y);
        }

        public Vector3 PointFromGrid(int x, int y)
        {
            return new Vector3(x, y * DirectionY, 0);
        }

        //public Vector2Int GridPoint(int col, int row)
        //{
        //    return new Vector2Int(col, row);
        //}

        public Vector2Int GridFromPoint(Vector3 point)
        {
            int col = CalcCoord(point.x);
            int row = CalcCoord(point.y * DirectionY);
            return new Vector2Int(col, row);
        }

        private int CalcCoord(float coord)
        {
            return Mathf.FloorToInt(Bias + coord);
        }
    }

}
