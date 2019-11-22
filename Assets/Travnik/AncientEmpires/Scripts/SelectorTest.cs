using System.Collections;
using System.Collections.Generic;
using Travnik.AncientEmpires;
using UnityEngine;
using Zenject;

public class SelectorTest : MonoBehaviour
{
    private IObjectSelector _selector;

    [Inject]
    public void Constructor(IObjectSelector selector)
    {
        _selector = selector;
    }

    // Start is called before the first frame update
    void Start()
    {
        //var gameObject = new GameObject("test").AddComponent<BoxCollider>();
        //Debug.DrawRay(transform.position, gameObject.transform.position,
        //    Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Input.mousePosition;
        Debug.Log("mouse pos " + pos);
        var result = _selector.Select(pos);
        Debug.Log("result=" + result.MapCell);
    }
}
