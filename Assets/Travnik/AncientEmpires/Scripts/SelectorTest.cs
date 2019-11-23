using System.Collections;
using System.Collections.Generic;
using Travnik.AncientEmpires;
using UnityEngine;
using Zenject;

public class SelectorTest : MonoBehaviour
{
    [SerializeField]private GameObject _selectCursorPrefab;
    private GameObject _selectCursor;
    private IObjectSelector _selector;
    private ISelect _currentSelect;

    [Inject]
    public void Constructor(IObjectSelector selector)
    {
        _selector = selector;
    }

    private void Awake()
    {
        //TODO configurate zenject
        _selectCursor = Instantiate(_selectCursorPrefab, transform);
        _selectCursor.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        //var gameObject = new GameObject("test").AddComponent<BoxCollider>();
        //Debug.DrawRay(transform.position, gameObject.transform.position,
        //    Color.red);
    }

    // Update is called once per frame
    private void Update()
    {
        var pos = Input.mousePosition;
        Debug.Log("mouse pos " + pos);
        _currentSelect = _selector.Select(pos);
        Debug.Log("result=" + _currentSelect.MapCell);
        DrawCursor();
    }

    private void DrawCursor()
    {
        Debug.Log("ongui");
        if (_currentSelect?.MapCell != null)
        {
            _selectCursor.SetActive(true);
            var pos = new Vector3(_currentSelect.MapCell.WorldPosition.x, _currentSelect.MapCell.WorldPosition.y, -5);
            Debug.Log("ongui=" + pos);
            _selectCursor.transform.position = pos;
        }
        else
        {
            _selectCursor.SetActive(false);
        }

    }
}
