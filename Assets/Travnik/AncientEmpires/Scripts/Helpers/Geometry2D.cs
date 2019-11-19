using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public class Geometry2D
    {
        public const float Scale = 2f;
        public const float Bias = 0.8f;

        public Vector3 PointFromGrid(Vector2Int gridPoint)
        {
            float x = Scale * gridPoint.x;
            float z = Scale * gridPoint.y;
            return new Vector3(x, 0, z);
        }

        public Vector2Int GridPoint(int col, int row)
        {
            return new Vector2Int(col, row);
        }

        public Vector2Int GridFromPoint(Vector3 point)
        {
            int col = CalcCoord(point.x);
            int row = CalcCoord(point.z);
            return new Vector2Int(col, row);
        }

        public int CalcCoord(float coord)
        {
            return Mathf.FloorToInt((Bias + coord) / Scale);
        }
    }

}
