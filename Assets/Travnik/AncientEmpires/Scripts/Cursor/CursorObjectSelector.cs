using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class CursorObjectSelector : MonoBehaviour
    {
        private IObjectSelector _objectSelector;

        [Inject]
        public void Constructor(IObjectSelector objectSelector)
        {
            _objectSelector = objectSelector;
        }

        private void Update()
        {
            var selected = _objectSelector.Select(Input.mousePosition);
            if (selected != null)
            {
                //TODO
            }
            Debug.Log("selected " + selected);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    enabled = true;
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
            //else
            //{
            //    enabled = false;
            //}
        }
    }
}
