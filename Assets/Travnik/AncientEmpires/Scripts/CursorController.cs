using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class CursorController : MonoBehaviour
    {
        private IObjectSelector _selector;
        private ISelect _currentSelect;
        private FooterPanelPresentor _footerPanelPresentor;
        private HeaderPanelPresentor _headerPanelPresentor;
        private CursorPresentor _cursorPresentor;

        [Inject]
        public void Constructor(IObjectSelector selector, 
            FooterPanelPresentor footerPanelPresentor,
            HeaderPanelPresentor headerPanelPresentor,
            CursorPresentor cursorPresentor)
        {
            _selector = selector;
            _footerPanelPresentor = footerPanelPresentor;
            _headerPanelPresentor = headerPanelPresentor;
            _cursorPresentor = cursorPresentor;
        }

        private void Update()
        {
            var pos = Input.mousePosition;
            Debug.Log("mouse pos " + pos);
            _currentSelect = _selector.Select(pos);
            Debug.Log("result=" + _currentSelect.MapCell);
            Show();
        }

        private void Show()
        {
            if (_currentSelect?.MapCell != null)
            {
                _cursorPresentor.Show(_currentSelect.MapCell.WorldPosition);
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
