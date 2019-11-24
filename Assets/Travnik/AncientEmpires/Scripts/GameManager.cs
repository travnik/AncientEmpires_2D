using Travnik.AncientEmpires;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IMapProvider _mapProvider;
    private IUnitProvider _unitProvider;

    [Inject]
    public void Constructor(IMapProvider mapProvider, IUnitProvider unitProvider)
    {
        _mapProvider = mapProvider;
        _unitProvider = unitProvider;
    }
    // Start is called before the first frame update
    private void Start()
    {
        _mapProvider.Load();
        _unitProvider.Load();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
