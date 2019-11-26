using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public class UnitMovablePositioner
    {
        private readonly IMapProvider _mapProvider;
        private readonly IUnitProvider _unitProvider;
        private int[,] _moveMarkMap;
        private readonly ICollection<MoveStep> _resultMoveSteps = new List<MoveStep>();

        private static readonly IEnumerable<Vector2Int> _directions = new List<Vector2Int>()
        {
            Vector2Int.right,
            Vector2Int.left,
            Vector2Int.up,
            Vector2Int.down
        };

        public UnitMovablePositioner(IMapProvider mapProvider, IUnitProvider unitProvider)
        {
            _mapProvider = mapProvider;
            _unitProvider = unitProvider;
        }

        public IEnumerable<MoveStep> CreateMovablePositions(IBaseUnit unit)
        {
            InitMoveMarkMap();
            _resultMoveSteps.Clear();
            var step = new MoveStep()
            {
                Position = unit.ArrayPosition,
                MovePoint = unit.MovePoint
            };
            CreateMovablePositions(unit,new MoveStep[] {step});
            return _resultMoveSteps;
        }

        private void CreateMovablePositions(IBaseUnit unit, IEnumerable<MoveStep> moveSteps)
        {
            var nextSteps = new List<MoveStep>();
            foreach (var step in moveSteps)
            {
                if(CanUnitMove(unit, step.Position))
                {
                    _resultMoveSteps.Add(step);
                }

                AddSteps(nextSteps, unit, step);
            }

            if (nextSteps.Any())
            {
                CreateMovablePositions(unit, nextSteps);
            }
        }

        private IEnumerable<MoveStep> AddSteps(List<MoveStep> nextSteps, IBaseUnit unit, MoveStep step)
        {
            foreach (var direction in _directions)
            {
                var nextPosition = step.Position + direction;
                var nextStep = CreateMovablePosition(unit, nextPosition, step.MovePoint);
                if (nextStep != null)
                {
                    nextSteps.Add(nextStep);
                }
            }

            return nextSteps;
        }

        private MoveStep CreateMovablePosition(IBaseUnit unit, Vector2Int position, int movePoint)
        {
            if (_mapProvider.IsValid(position.x, position.y))
            {
                var mapCell = _mapProvider.Get(position.x, position.y);
                var costMove = mapCell.MapCellInfo.CostMove;
                var deltaMove = movePoint - costMove;
                if (deltaMove > _moveMarkMap[position.x, position.y])
                {
                    if (costMove <= movePoint)
                    {
                        if (CanMoveThrough(unit, position))
                        {
                            var step = new MoveStep()
                            {
                                Position = position,
                                MovePoint = deltaMove
                            };
                            _moveMarkMap[position.x, position.y] = deltaMove;
                            return step;
                        }
                    }
                }
            }

            return null;
        }

        private void InitMoveMarkMap()
        {
            _moveMarkMap = new int[_mapProvider.SizeX, _mapProvider.SizeY];
            for (var i = 0; i < _moveMarkMap.GetLength(0); i++)
            {
                for (var j = 0; j < _moveMarkMap.GetLength(1); j++)
                {
                    _moveMarkMap[i, j] = Int32.MinValue;
                }
            }
        }

        public bool CanUnitMove(IBaseUnit unit, Vector2Int destPos)
        {
            if (_mapProvider.IsValid(destPos.x, destPos.y))
            {
                var destUnit = _unitProvider.Get(destPos);
                return destUnit == null || IsSameUnit(unit, destUnit);
            }

            return false;
        }

        private static bool IsSameUnit(IBaseUnit unit, IBaseUnit destUnit)
        {
            return unit.ArrayPosition == destUnit.ArrayPosition;
        }

        public int GetMovementPointCost(IBaseUnit unit, Vector2Int destPos)
        {
            var tile = _mapProvider.Get(destPos.x, destPos.y);
            var mpCost = tile.MapCellInfo.CostMove;

            //TODO специальное перемещение у юнита
            return mpCost;
        }

        private bool CanMoveThrough(IBaseUnit unit, Vector2Int targetPos)
        {
            var targetUnit = _unitProvider.Get(targetPos);
            if (targetUnit == null)
            {
                return true;
            }

            return IsEnemy(unit, targetUnit) && IsEnemyMove(unit, targetUnit);
        }

        private bool IsEnemy(IBaseUnit unit, IBaseUnit targetUnit)
        {
            return unit.PlayerTeam != targetUnit.PlayerTeam;
        }

        private bool IsEnemyMove(IBaseUnit unit, IBaseUnit targetUnit)
        {
            //TODO добавить проверку способнойтей для перемещения через врага
            return false;
        }
    }
}
