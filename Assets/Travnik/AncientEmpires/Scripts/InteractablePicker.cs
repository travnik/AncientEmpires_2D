using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractablePicker : MonoBehaviour
{
    private Camera _camera;

    [Inject]
    public void Constructor(Camera camera)
    {
        _camera = camera;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Vector2Int gridPoint = Geometry.GridFromPoint(hit.point);

            //_tileHighlight.SetActive(true);
            //var vector3 = Geometry.PointFromGrid(gridPoint);
            //vector3.y = 0.6f;
            //_tileHighlight.transform.position = vector3;

            if (Input.GetMouseButtonDown(0))
            {
                //PlayerCharacter playerScript = UnitsController.Instance.GetPlayerAtGrid(gridPoint);
                //SelectPlayer(playerScript);
            }
        }
    }
}
