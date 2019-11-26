using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class CursorController : MonoBehaviour
    {
        private IObjectSelector _selector;
        private FooterPanelPresentor _footerPanelPresentor;
        private HeaderPanelPresentor _headerPanelPresentor;
        private CursorPresentor _cursorPresentor;
        private IUnitMovablePositioner _unitMovablePositioner;

        private ISelect _currentSelect;

        [Inject]
        public void Constructor(IObjectSelector selector, 
            FooterPanelPresentor footerPanelPresentor,
            HeaderPanelPresentor headerPanelPresentor,
            CursorPresentor cursorPresentor,
            IUnitMovablePositioner unitMovablePositioner)
        {
            _selector = selector;
            _footerPanelPresentor = footerPanelPresentor;
            _headerPanelPresentor = headerPanelPresentor;
            _cursorPresentor = cursorPresentor;
            _unitMovablePositioner = unitMovablePositioner;
        }

        private void Update()
        {
            var pos = Input.mousePosition;
            _currentSelect = _selector.Select(pos);
            Show();

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                if (_currentSelect.Unit != null)
                {
                    var result = _unitMovablePositioner.CreateMovablePositions(_currentSelect.Unit);
                    Debug.Log("result=" + result);
                }
            }
        }

        private void Show()
        {
            if (_currentSelect?.MapCell != null)
            {
                _cursorPresentor.ShowSelect(_currentSelect.MapCell.WorldPosition);
                _footerPanelPresentor.Present(_currentSelect.MapCell);
            }
            else
            {
                _cursorPresentor.Hide();
                _footerPanelPresentor.Clear();
            }

            _headerPanelPresentor.Present(_currentSelect?.Unit);
        }
    }
}
