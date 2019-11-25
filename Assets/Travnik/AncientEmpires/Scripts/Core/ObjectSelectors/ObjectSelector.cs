using System;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class ObjectSelector : IObjectSelector
    {
        private Camera _camera;
        private IMapProvider _mapProvider;
        private IGeometry _geometry;
        private IUnitProvider _unitProvider;

        [Inject]
        public void Constructor(Camera camera, 
            IMapProvider mapProvider, 
            IGeometry geometry, 
            IUnitProvider unitProvider)
        {
            _camera = camera;
            _mapProvider = mapProvider;
            _geometry = geometry;
            _unitProvider = unitProvider;
        }

        public ISelect Select(Vector3 position)
        {
            var screenToWorldPoint = Camera.main.ScreenToWorldPoint(position);
            var point = _geometry.GridFromPoint(screenToWorldPoint);

            var select = new SelectObject();
            if (_mapProvider.IsValid(point.x, point.y))
            {
                select.MapCell = _mapProvider.Get(point.x, point.y);
            }

            select.Unit = _unitProvider.Get(point);

            return select;

            //Debug.Log("screenToWorldPoint= " + screenToWorldPoint);
            //RaycastHit hit = CastFromPosition(position);
            //Debug.Log("hit " + hit);
            //if (hit.transform != null)
            //{
            //    Debug.Log("select point " + hit.point);
            //    return new SelectObject();
            //    //enabled = true;
            //    //Vector2Int gridPoint = Geometry.GridFromPoint(hit.point);

            //    //_tileHighlight.SetActive(true);
            //    //var vector3 = Geometry.PointFromGrid(gridPoint);
            //    //vector3.y = 0.6f;
            //    //_tileHighlight.transform.position = vector3;

            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        //PlayerCharacter playerScript = UnitsController.Instance.GetPlayerAtGrid(gridPoint);
            //        //SelectPlayer(playerScript);
            //    }

                
            //}

            //return null;
        }

        private RaycastHit CastFromPosition(Vector3 position)
        {
            Ray ray = _camera.ScreenPointToRay(position);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit;
        }
    }
}
