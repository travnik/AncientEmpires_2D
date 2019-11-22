using System.Collections;
using System.Collections.Generic;
using Travnik.AncientEmpires;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IMapProvider _mapProvider;

    [Inject]
    public void Constructor(IMapProvider mapProvider)
    {
        _mapProvider = mapProvider;
    }
    // Start is called before the first frame update
    private void Start()
    {
        _mapProvider.Load();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
